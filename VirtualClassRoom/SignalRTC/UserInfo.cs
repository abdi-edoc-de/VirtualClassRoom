using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.SignalRTC
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public string ConnectionId { get; set; }
        public string CallId { get; set; }
        public bool HasAudio { get; set; }
        public bool HasVideo { get; set; }
    }
}
