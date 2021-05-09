using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Moq;

namespace VirtualClassRoom.Entities
{
    public class Resource
    {
        [Key]
        public Guid ResourceId { get; set; }
        [Required]
        public String FilePath { get; set; }
        [Required]
        public String FileName { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
        public DateTime CreationDate { get; set; }
        public Resource()
        {
            this.CreationDate = DateTime.UtcNow;
        }

    }
}
