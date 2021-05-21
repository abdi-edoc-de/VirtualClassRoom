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
    }
}
