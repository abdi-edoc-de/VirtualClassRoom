using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services.CourseStudents
{
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseStudentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public void AddStudentInCourse(CourseStudent courseStudent)
        {

            if (courseStudent == null)
            {
                throw new ArgumentNullException(nameof(courseStudent));
            }
            _appDbContext.CourseStudents.Add(courseStudent);
            _appDbContext.SaveChanges();
            
        }

        public IEnumerable<Student> GetStudents(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            List<CourseStudent> courseStudent = _appDbContext.CourseStudents
                .Where(c=>c.CourseId==courseId).ToList();
            List<Student> students=new List<Student>();
            foreach(CourseStudent i in courseStudent)
            {
                students.Add(
                    _appDbContext.Students.First(c=>c.StudentId==i.StudentId));
            }
            return students;

        }
        public IEnumerable<Student> GetStudents(IEnumerable<Guid> studentIds)
        {
            if (studentIds == null)
            {
                throw new ArgumentNullException(nameof(studentIds));
            }
            return _appDbContext.Students.Where(s => studentIds.Contains(s.StudentId)).ToList();
        }
    }
}
