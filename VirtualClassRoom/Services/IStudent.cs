using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IStudent
    {
        //IEnumerable<>
        public Student FindStudent(String  email,String password);
        public Student GetStudent(Guid studentId);
        public void UpdateStudent(Guid studentId);
        public void AddStudent(Student student);
        public void DeleteStudent(Guid studentId);

    }
}
