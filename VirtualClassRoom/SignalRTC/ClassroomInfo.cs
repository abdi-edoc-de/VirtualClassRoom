using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.SignalRTC
{
    public class ClassroomInfo
    {
        public ConcurrentDictionary<string, UserInfo> Participants;
        public bool CanChat;
    }
}
