using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;
//using VirtualClassRoom.ValidationAtrributes;

namespace VirtualClassRoom.Models.Users
{
    public class UserBaseDto : IValidatableObject
    {
        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var _instructorRepository = (IInstructorRepository)validationContext.GetService(typeof(IInstructorRepository));
            var _studentRepository = (IStudentRepository)validationContext.GetService(typeof(IStudentRepository));

            if (_instructorRepository.InstrucotrExistByEmail(Email) ||
                _studentRepository.StudentExistByEmail(Email))
            {
                yield return new ValidationResult(
                    "The Email is Taken",
                    new[] { "Email" });
            }
        }
    }
}
