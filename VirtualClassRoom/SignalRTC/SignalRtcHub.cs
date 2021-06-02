using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.SignalRTC
{
    public class SignalRtcHub: Hub
    {
        private readonly IAccountService _accountService;
        private readonly IStudentRepository _studentRepository;
        private readonly IInstructorRepository _instructorRepository;
        

        // holds the connectionID to callID mapping
        static ConcurrentDictionary<string, string> concurrentDictionary = new ConcurrentDictionary<string, string>();
        // holds the connectionID to groupID mapping
        static ConcurrentDictionary<string, string> groupDictionary = new ConcurrentDictionary<string, string>();
        // holds the groupID to Classroom info mapping
        static ConcurrentDictionary<string, ClassroomInfo> groupInformation = new ConcurrentDictionary<string, ClassroomInfo>();

        public SignalRtcHub(IAccountService accountService, IStudentRepository studentRepository, IInstructorRepository instructorRepository)
        {
            _accountService = accountService;
            _studentRepository = studentRepository;
            _instructorRepository = instructorRepository;
        }

        public async Task JoinRoom(string userCallID, string groupName, string authHeader)
        {
            string username = _accountService.Decrypt(authHeader);
            string[] token = username.Split(",");
            Guid id = Guid.Parse(token[0].Trim());
            string role = token[1].Trim();

            UserInfo newUser = await GetUserInfo(id, role, userCallID);
            groupInformation.TryGetValue(groupName, out var classInfo);
            //var classInfo = groupInformation[groupName];
            if (classInfo == null)
            {
                classInfo = new ClassroomInfo()
                {
                    Participants = new ConcurrentDictionary<string, UserInfo>(),
                    CanChat = true
                };
            }
            classInfo.Participants.TryAdd(newUser.CallId, newUser);
            await Clients.Client(Context.ConnectionId).SendAsync("ClassInfo", JsonSerializer.Serialize(classInfo.Participants));
            groupInformation[groupName] = classInfo;
            Console.WriteLine(JsonSerializer.Serialize(classInfo.Participants));

            await Clients.Group(groupName).SendAsync("UserConnected", JsonSerializer.Serialize(newUser));
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            concurrentDictionary.TryAdd(Context.ConnectionId, userCallID);
            groupDictionary.TryAdd(Context.ConnectionId, groupName);
        }

        private async Task<UserInfo> GetUserInfo(Guid id, string role, string callId)
        {
            string UserName;
            if (role == "Student")
            {
                var user = await _studentRepository.GetStudent(id);
                UserName = user.FirstName + " " + user.LastName;
            } else
            {
                var user = await _instructorRepository.GetInstructor(id);
                UserName = user.FirstName + " " + user.LastName;
            }
            return new UserInfo()
            {
                UserName = UserName,
                Role = role,
                ConnectionId = Context.ConnectionId,
                CallId = callId,
                HasAudio = false,
                HasVideo = false
            };
            
        }

        public async Task SendMute(string userCallID, string groupName){
            await Clients.GroupExcept(groupName, userCallID).SendAsync("MakeMute", userCallID);
        }

        public async Task SendUnMute(string userCallID, string groupName)
        {
            await Clients.GroupExcept(groupName, userCallID).SendAsync("MakeUnMute", userCallID);
        }

        public async Task ScreenShare(string userCallID, string groupName)
        {
            // Add user to group
            groupInformation.TryGetValue(groupName, out var classInfo);
            if (classInfo == null)
            {
                Console.WriteLine("Got a stream request from an empty class. Should never happen, report bug");
                return;
            }


            var streamInfo = new UserInfo()
            {
                UserName = "Instructor's stream}",
                Role = "Instructor",
                ConnectionId = Context.ConnectionId,
                CallId = userCallID,
                HasAudio = false,
                HasVideo = true
            };

            classInfo.Participants.TryAdd(userCallID, streamInfo);
            groupInformation[groupName] = classInfo;

            await Clients.Group(groupName).SendAsync("UserConnected", JsonSerializer.Serialize(streamInfo));
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            concurrentDictionary.TryAdd(Context.ConnectionId, userCallID);
            groupDictionary.TryAdd(Context.ConnectionId, groupName);
        }


        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            concurrentDictionary.TryGetValue(Context.ConnectionId, out string username);
            groupDictionary.TryGetValue(Context.ConnectionId, out string groupName);

            if (username != null)
            {
                DropUser(groupName, username);
            }

            await base.OnDisconnectedAsync(exception);
        }

        async void DropUser(string groupName, string username)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("UserDisconnected", username);

            groupInformation.TryGetValue(groupName, out var classInfo);
            if (classInfo != null)
            {
                classInfo.Participants.TryRemove(username, out UserInfo _);
                groupInformation[groupName] = classInfo;
            }
            await Clients.Group(groupName).SendAsync("ClassInfo", JsonSerializer.Serialize(classInfo.Participants));

        }
    }
}
