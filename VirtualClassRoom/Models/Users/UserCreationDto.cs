using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Models
{
    public class UserCreationDto
    {
        public String FirstName { get; set; }
       
        public String LastName { get; set; }
        
        public String Email { get; set; }
        public string Password { get; set; }

    }
}
