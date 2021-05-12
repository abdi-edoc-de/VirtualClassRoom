using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public class StudentRepository : IStudent
    {
        private readonly AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
        }

        public void DeleteStudent(Guid studentId)
        {
            if(studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            Student student = _appDbContext.Students.FirstOrDefault(s => s.StudentId == studentId) ??
                throw new ArgumentNullException(nameof(student));
            _appDbContext.Students.Remove(student);
        }

        public Student FindStudent(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(email));
            }
            email = email.Trim();
            password = password.Trim();
            Student student = _appDbContext.Students.FirstOrDefault(s => s.Email == email && s.Password == password) ??
                throw new ArgumentNullException(nameof(student));
            return student;
            

        }

        public Student GetStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _appDbContext.Students
                        .FirstOrDefault(c => c.StudentId == studentId);
                        
        }

        public void UpdateStudent(Guid studentId)
        {
            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            var student = _appDbContext.Students.FirstOrDefault(c => c.StudentId == studentId);
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));

            }
            _appDbContext.Update(student);
            _appDbContext.SaveChanges();
        }
    }
}
