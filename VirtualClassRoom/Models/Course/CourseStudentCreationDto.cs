using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.Course
{
    public class CourseStudentCreationDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

    }
}
