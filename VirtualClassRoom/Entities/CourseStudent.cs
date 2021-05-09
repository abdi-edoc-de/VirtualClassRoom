using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Entities
{
    public class CourseStudent
    {
        //for many to many relationship
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        public Guid StudentId { get; set; }


        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public Guid CourseId { get; set; }


    }
}
