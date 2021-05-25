using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services.CourseStudents
{
    public interface ICourseStudentRepository
    {
        public void AddStudentInCourse(CourseStudent courseStudent);
        public IEnumerable<Student> GetStudents(Guid courseId);
    }
}
