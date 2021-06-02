using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.ClassRooms
{
    public class ClassRoomCreationDto
    {

        [Required]
        public String ClassRoomName { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]

        public string StartTime { get; set; }
        [Required]

        public string EndTime { get; set; }
        [Required]

        public Guid CourseId { get; set; }
    }
}
