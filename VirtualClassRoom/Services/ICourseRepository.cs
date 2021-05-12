using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface ICourseRepository
    {
        public ICollection<CourseStudent> GetCoursesForINstructor(Guid instructorId);
        public void AddCourses(Guid instructorId, Course course);
        public ICollection<Course> GetCourses();
        public ICollection<CourseStudent> GetEnrolledCourses(Guid studentId);
        public void DeleteCourse(Guid courseId);
        public void UpdateCourse(Guid courseId);
    }
}
