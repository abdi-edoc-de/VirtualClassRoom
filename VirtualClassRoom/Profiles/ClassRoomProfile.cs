using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models.ClassRooms;

namespace VirtualClassRoom.Profiles
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {

            CreateMap<ClassRoom, ClassRoomDto>();
        }
    }
}
