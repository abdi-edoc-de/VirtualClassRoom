using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models.Course;
using VirtualClassRoom.Services;
using VirtualClassRoom.Services.CourseStudents;

namespace VirtualClassRoom.Profiles
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseCreationDto>();
            CreateMap<CourseCreationDto, Course>();
            CreateMap<Course, CourseCreationDto>();


            CreateMap<CourseStudentCreationDto, CourseStudent>();
            CreateMap<Course, CourseDto>();
        }
    }
}
