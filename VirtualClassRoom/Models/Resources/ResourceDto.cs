using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.Resources
{
    public class ResourceDto
    {
        public Guid ResourceId { get; set; }
        public String FileName { get; set; }
        
        public Guid CourseId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
