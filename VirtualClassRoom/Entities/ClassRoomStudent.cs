using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualClassRoom.Entities
{
    public class ClassRoomStudent 
    {
        //for many to many relationship
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public Guid StudentId { get; set; }


        [ForeignKey("ClassRoomId")]
        public ClassRoom ClassRoom { get; set; }
        public Guid ClassRoomId { get; set; }

        public bool Attendance { get; set; }

    }
}
