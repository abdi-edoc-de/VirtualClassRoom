using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.Course
{
    public class CourseCreationDto
    {
        [Required]
        [MaxLength(100)]
        public String Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public String Description { get; set; }
        [Required]
        public Guid InstructorId { get; set; }
    }
}
