using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;
using VirtualClassRoom.Services.CourseStudents;

namespace VirtualClassRoom.Models.Users
{
    public class UserCred : IValidatableObject
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var _studentRepository = (IStudentRepository)validationContext.GetService(typeof(IStudentRepository));
            var _instructorRepository = (IInstructorRepository)validationContext.GetService(typeof(IInstructorRepository));

            

            if (_studentRepository.FindStudentNonAsync(UserName,Password) ==null &&
                _instructorRepository.FindInstructorNonAsync(UserName,Password)==null)

            {
                yield return new ValidationResult(
                    "UserName or Password incorret",
                    new[] { "login" });
            }
        }
    }
}
