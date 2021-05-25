using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface ICourseRepository
    {
        public bool CourseExist(Guid courseId);

        public ICollection<Course> GetCoursesForInstructor(Guid instructorId);
        public void AddCourse(Guid instructorId, Course course);
        public ICollection<Course> GetCourses();
        public ICollection<CourseStudent> GetEnrolledCourses(Guid studentId);
        public void DeleteCourse(Guid courseId);
        public void UpdateCourse(Course course);
        public Course GetCourse(Guid courseId);

    }
}
