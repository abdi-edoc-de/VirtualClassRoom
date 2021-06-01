using Microsoft.EntityFrameworkCore;
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
        public async Task<CourseStudent> AddStudentInCourse(CourseStudent courseStudent)
        {

            if (courseStudent == null)
            {
                throw new ArgumentNullException(nameof(courseStudent));
            }
            _appDbContext.CourseStudents.Add(courseStudent);
            await _appDbContext.SaveChangesAsync();
            return courseStudent;


        }

        public async Task<IEnumerable<Student>> GetStudents(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            List<CourseStudent> courseStudent = await _appDbContext.CourseStudents
                .Where(c => c.CourseId == courseId).ToListAsync();
            List<Student> students = new List<Student>();
            foreach (CourseStudent i in courseStudent)
            {
                students.Add(
                    await _appDbContext.Students.FirstAsync(c => c.StudentId == i.StudentId));
            }
            return students;

        }
        public async Task<IEnumerable<Student>> GetStudents(IEnumerable<Guid> studentIds)
        {
            if (studentIds == null)
            {
                throw new ArgumentNullException(nameof(studentIds));
            }
            return await _appDbContext.Students.Where(s => studentIds.Contains(s.StudentId)).ToListAsync();
        }

        public async Task<CourseStudent> RemoveStudentFromCourse(Guid studentId, Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            var courseStudent = await _appDbContext.CourseStudents.FirstOrDefaultAsync(cs=>cs.CourseId==courseId && cs.StudentId==studentId);
            if(courseStudent == null)
            {
                return null;
            }
             _appDbContext.Remove(courseStudent);
            await _appDbContext.SaveChangesAsync();
            return courseStudent;

        }

        public bool StudentExistInCourse(Guid studentId, Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return _appDbContext.CourseStudents.Any(cs=>cs.StudentId==studentId && cs.CourseId==courseId);

        }
    }
}
