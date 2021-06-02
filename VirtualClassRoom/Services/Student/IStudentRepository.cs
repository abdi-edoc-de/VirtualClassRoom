using System;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

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
        public Task<Student> FindStudent(String email, String password);
        public Student FindStudentNonAsync(String email, String password);

        public Task<Student> GetStudent(Guid studentId);
        public Task<Student> UpdateStudent(Guid studentId, Student student);
        public Task<Student> AddStudent(Student student);
        public Task<Student> DeleteStudent(Guid studentId);
        public Task<bool> StudentExist(Guid studentId);
        public Task<Student> GetStudentByEmail(string email);
        public Task<IEnumerable<Student>> GetStudentByEmail(IEnumerable<string> email);

        public bool StudentExistByEmail(string email);
        public bool StudentExistNoneAsync(Guid studentId);



    }
}
