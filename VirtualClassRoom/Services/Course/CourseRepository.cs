using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<Course> AddCourse(Guid instructorId, Course course)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }
            var instructor = await _appDbContext.Instructors.FirstOrDefaultAsync(i => i.InstructorId == instructorId);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            course.InstructorId = instructorId;
            course.Instructor = instructor ?? throw new ArgumentNullException(nameof(instructor));
            _appDbContext.Courses.Add(course);
            await _appDbContext.SaveChangesAsync();
            return course;
        }


        public async Task<ICollection<Course>> GetEnrolledCourses(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            var courseStudents = await _appDbContext.CourseStudents
                        .Where(c => c.StudentId == studentId)
                        .ToListAsync();
            List<Guid> courseIds = courseStudents.Select(cs => cs.CourseId).ToList();
            var courses = await _appDbContext.Courses.Where(c => courseIds.Contains(c.CourseId)).ToListAsync();
            return courses;

        }
        public async Task<ICollection<Course>> GetCourses()
        {
            return await _appDbContext.Courses.ToListAsync();
        }

        public async Task<ICollection<Course>> GetCoursesForInstructor(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }

            return await _appDbContext.Courses
                        .Where(c => c.InstructorId == instructorId)
                        .ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            _appDbContext.Update(course);
            await _appDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteCourse(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            var course = await _appDbContext.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));

            }
            _appDbContext.Courses.Remove(course);
            await _appDbContext.SaveChangesAsync();

            return course;
        }

        public async Task<bool> CourseExist(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            return await _appDbContext.Courses.AnyAsync(s => s.CourseId == courseId);
        }

        public async Task<Course> GetCourse(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            return await _appDbContext.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);

        }
    }
}
