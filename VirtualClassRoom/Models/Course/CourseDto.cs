using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.Course
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Guid InstructorId { get; set; }
    }
}
