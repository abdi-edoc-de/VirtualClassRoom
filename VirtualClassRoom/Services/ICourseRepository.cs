using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface ICourseRepository
    {
        ICollection<CourseStudent> GetCoursesForINstructor(Guid instructorId);
        void AddCourses(Guid instructorId, Course course);
        ICollection<Course> GetCourses();
        ICollection<CourseStudent> GetCourses(Guid studentId);


    }
}
