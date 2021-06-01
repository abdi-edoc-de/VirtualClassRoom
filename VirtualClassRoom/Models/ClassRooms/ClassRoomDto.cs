using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.ClassRooms
{
    public class ClassRoomDto
    {
        public Guid ClassRoomId { get; set; }

        public String ClassRoomName { get; set; }
        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Guid CourseId { get; set; }

    }
}
