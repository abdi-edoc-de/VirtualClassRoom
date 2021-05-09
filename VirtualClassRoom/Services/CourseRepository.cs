using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;

        public CourseRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext)); 
        }
        public void AddCourses(Guid instructorId, Course course)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }

            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            // always set the AuthorId to the passed-in authorId
            course.InstructorId = instructorId;
            _appDbContext.Courses.Add(course);
            _appDbContext.SaveChanges();
        }

  
        public ICollection<Course> GetCourses(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }

            return _appDbContext.Courses
                        .Where(c => c.InstructorId == instructorId)
                        .OrderBy(c => c.Title).ToList();
        }
    }
}
