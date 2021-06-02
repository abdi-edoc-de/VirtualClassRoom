using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models.Resources;

namespace VirtualClassRoom.Profiles
{
    public class ResourceProfile :Profile
    {
        public ResourceProfile()
        {
            CreateMap<ResourceDto, Resource>();
            CreateMap<Resource, ResourceDto>();


        }
    }
}
