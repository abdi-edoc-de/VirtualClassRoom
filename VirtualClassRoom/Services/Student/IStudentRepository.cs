using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IStudentRepository
    {
        //IEnumerable<>
        public Student FindStudent(String  email,String password);
        public Student GetStudent(Guid studentId);
        public void UpdateStudent(Guid studentId,Student student);
        public void AddStudent(Student student);
        public void DeleteStudent(Guid studentId);
        public bool StudentExist(Guid studentId);
        public Student GetStudentByEmail(string email);
       

    }
}
