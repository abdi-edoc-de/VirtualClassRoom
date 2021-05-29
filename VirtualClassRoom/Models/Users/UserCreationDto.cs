using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Models.Users;

namespace VirtualClassRoom.Models
{
    public class UserCreationDto:UserBaseDto
    {
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

    }
}
