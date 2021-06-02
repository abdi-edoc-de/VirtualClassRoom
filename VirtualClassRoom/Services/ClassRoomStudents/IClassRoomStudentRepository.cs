using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services.ClassRoomStudents
{
    public interface IClassRoomStudentRepository
    {
        public Task<ClassRoomStudent> AddClassRoomStudent(ClassRoomStudent classRoomStudent);
        public Task<IEnumerable<Student>> AddClassRoomStudent(Guid classRoomId);

    }
}
