using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Entities
{
    public class ClassRoomUpdateDto
    {
        [Required]
        public String ClassRoomName { get; set; }

    }
}
