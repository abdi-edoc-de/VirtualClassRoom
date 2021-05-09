using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace VirtualClassRoom.Entities
{
    public class ClassRoom
    {
        [Key]
        public Guid ClassRoomId { get; set; }

        [Required]
        [MaxLength(50)]
        public String ClassRoomName { get; set; }

        [Required]
        public String Url { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
        public ICollection<ClassRoomStudent> ClassRoomStudents { get; set; } = new List<ClassRoomStudent>();

    }
}
