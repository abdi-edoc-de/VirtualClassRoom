using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models;
using VirtualClassRoom.Models.User;
using VirtualClassRoom.Models.Users;

namespace VirtualClassRoom.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Student, UserAuthenticationDto>()
              .ForMember(
              dest => dest.Name,
              opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
              .ForMember(
              dest => dest.Id,
              opt => opt.MapFrom(src => src.StudentId));

            //CreateMap<Instructor, UserAuthenticationDto>()
            //  .ForMember(
            //  dest => dest.Name,
            //  opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            //  .ForMember(
            //  dest => dest.Id,
            //  opt => opt.MapFrom(src => src.InstructorId));


            CreateMap<Student, UserDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.StudentId));
            CreateMap<UserCreationDto, Student>();
            // .ForMember(
              //  dest => dest.Password,
                //opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

            CreateMap<Student, UserAuthenticationDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.StudentId));
            CreateMap<Instructor, UserDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InstructorId));
            CreateMap<UserCreationDto, Instructor>()
                .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));
            CreateMap<Instructor, UserAuthenticationDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InstructorId));

            CreateMap<UserUpdateDto, Student>();
            CreateMap<Student, UserUpdateDto>();
            CreateMap<UserUpdateDto, Instructor>();
            CreateMap<Instructor, UserUpdateDto>();


        }
    }
}
