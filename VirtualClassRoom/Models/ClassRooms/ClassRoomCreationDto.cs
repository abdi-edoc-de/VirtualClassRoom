using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.ClassRooms
{
    public class ClassRoomCreationDto : IValidatableObject
    {

        [Required]
        public String ClassRoomName { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]

        public string StartTime { get; set; }
        [Required]

        public string EndTime { get; set; }
        [Required]

        public Guid CourseId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            DateTime now = DateTime.UtcNow;
            if (Convert.ToDateTime(Date)<now)
            {
                yield return new ValidationResult(
                    "The Date must be in future or now",
                    new[] { "Date" });
            }
        }
    }
}
