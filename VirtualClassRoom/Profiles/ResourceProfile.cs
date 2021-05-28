using AutoMapper;
using AutoMapper.XpressionMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Models.Resources;

namespace VirtualClassRoom.Profiles
{
    public class ResourceProfile:Profile
    {
        public ResourceProfile()
        {
            CreateMap<Resource, ResourceDto>();

        }
    }
}
