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

            
            CreateMap<ClassRoom, ClassRoomDto>()
                 .ForMember(
                dest => dest.StartTime,
                opt => opt.MapFrom(src => src.StartTime.ToString()))
                 .ForMember(
                dest => dest.EndTime,
                opt => opt.MapFrom(src => src.EndTime.ToString()));

            CreateMap<ClassRoomCreationDto, ClassRoom>()
                 .ForMember(
                dest => dest.StartTime,
                opt => opt.MapFrom(src => TimeSpan.Parse(src.StartTime)))
                 .ForMember(
                dest => dest.EndTime,
                opt => opt.MapFrom(src => TimeSpan.Parse(src.EndTime)))
                  .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => Convert.ToDateTime(src.Date)));
        }
    }
}
