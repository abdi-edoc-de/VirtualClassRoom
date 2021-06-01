using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services.CourseStudents
{
    public interface ICourseStudentRepository
    {
        public  Task<CourseStudent> AddStudentInCourse(CourseStudent courseStudent);
        public Task<IEnumerable<Student>> GetStudents(Guid courseId);
        public Task<IEnumerable<Student>> GetStudents(IEnumerable<Guid> studentIds);
        public bool StudentExistInCourse(Guid studentIds,Guid courseId);
        public Task<CourseStudent> RemoveStudentFromCourse(Guid studentIds, Guid courseId);


    }
}
