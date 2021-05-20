using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models.Instrucotr
{
    public class InstructorDto
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MyProperty { get; set; }

    }
}
