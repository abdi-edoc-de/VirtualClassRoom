using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualClassRoom.Entities
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public String FirstName { get; set;      }
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }
        [Required]
        [MinLength(8)]
        public String Password { get; set; }
        
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        //we have to list forign keys object
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

        public ICollection<ClassRoomStudent> ClassRoomStudents { get; set; } = new List<ClassRoomStudent>();

        public static implicit operator Student(Task<Student> v)
        {
            throw new NotImplementedException();
        }
    }
}
