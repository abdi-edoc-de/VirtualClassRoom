using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface ICourseRepository
    {
        public Task<bool> CourseExist(Guid courseId);
        public bool CourseExistNoneAsync(Guid courseId);

        public Task<ICollection<Course>> GetCoursesForInstructor(Guid instructorId);
        public Task<Course> AddCourse(Guid instructorId, Course course);
        public Task<ICollection<Course>> GetCourses();
        public Task<ICollection<Course>> GetEnrolledCourses(Guid studentId);
        public Task<Course> DeleteCourse(Guid courseId);
        public Task<Course> UpdateCourse(Course course);
        public Task<Course> GetCourse(Guid courseId);

    }
}
