using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface ICourseRepository
    {
        ICollection<Course> GetCourses(Guid instructorId);
        void AddCourses(Guid instructorId, Course course);

    }
}
