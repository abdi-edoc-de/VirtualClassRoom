using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace VirtualClassRoom.SignalRTC
{
    public class SignalRtcHub: Hub
    {
        static ConcurrentDictionary<string, string> concurrentDictionary = new ConcurrentDictionary<string, string>();
        static ConcurrentDictionary<string, string> groupDictionary = new ConcurrentDictionary<string, string>();

        public async Task JoinRoom(string username, string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("UserConnected", username);

            concurrentDictionary.TryAdd(Context.ConnectionId, username);
            groupDictionary.TryAdd(Context.ConnectionId, groupName);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            concurrentDictionary.TryGetValue(Context.ConnectionId, out string username);
            groupDictionary.TryGetValue(Context.ConnectionId, out string groupName);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("UserDisconnected", username);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
