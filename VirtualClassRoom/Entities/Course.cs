using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualClassRoom.Entities
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        [MaxLength(100)]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [ForeignKey("InstructorId")]
        public Instructor Instructor { get; set; }
        public Guid InstructorId { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

        public ICollection<Resource> Resources { get; set; }
            = new List<Resource>();
        public ICollection<ClassRoom> ClassRooms { get; set; }
            = new List<ClassRoom>();

    }
}