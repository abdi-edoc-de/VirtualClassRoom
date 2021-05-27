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

        public override Task OnConnectedAsync()
        {

            return base.OnConnectedAsync();
        }
        public async Task JoinRoom(string username)
        {
            await Clients.Others.SendAsync("UserConnected", username);
            concurrentDictionary.TryAdd(Context.ConnectionId, username);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            concurrentDictionary.TryGetValue(Context.ConnectionId, out string username);
            await Clients.All.SendAsync("UserDisconnected", username);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
