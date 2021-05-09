using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualClassRoom.Entities
{
    public class Instructor
    {
        [Key]
        public Guid TeacherId { get; set; }
        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }
        private string _password;
        [NotMapped]
        public String Password
        {
            get
            {
                // password hashing and attribute for password field
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        //we have to list forign keys object
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
