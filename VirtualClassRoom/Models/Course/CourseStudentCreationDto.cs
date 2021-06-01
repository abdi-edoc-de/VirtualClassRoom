using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Services;
using VirtualClassRoom.Services.CourseStudents;

namespace VirtualClassRoom.Models.Course
{
    public class CourseStudentCreationDto : IValidatableObject
    {

        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public Guid CourseId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var _couresRepository = (ICourseRepository)validationContext.GetService(typeof(ICourseRepository));
            var _studentRepository = (IStudentRepository)validationContext.GetService(typeof(IStudentRepository));
            var _courseStudentRepository = (ICourseStudentRepository)validationContext.GetService(typeof(ICourseStudentRepository));


            if (!_studentRepository.StudentExistNoneAsync(StudentId))

            {
                yield return new ValidationResult(
                    "The Student Does not Eixist",
                    new[] { "UserBaseDto" });
            }
            if (!_couresRepository.CourseExistNoneAsync(CourseId))

            {
                yield return new ValidationResult(
                    "The Course Does not Eixist",
                    new[] { "UserBaseDto" });
            }
            if (_courseStudentRepository.StudentExistInCourse(StudentId,CourseId))

            {
                yield return new ValidationResult(
                    "The Student Already Eixist in the course",
                    new[] { "UserBaseDto" });
            }
        }

    }
   
}
