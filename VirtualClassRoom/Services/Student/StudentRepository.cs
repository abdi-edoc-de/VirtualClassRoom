using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public class StudentRepository : IStudentRepository
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
            if(studentId == Guid.Empty)
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
            Student student = _appDbContext.Students.FirstOrDefault(s => s.Email == email && s.Password == password);
            if (student == null)
            { return null; }
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

        public void UpdateStudent(Guid studentId,Student student)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            //Student studentFromDb = _appDbContext.Students.FirstOrDefault(c => c.StudentId == studentId) ??
            //    throw new ArgumentNullException(nameof(studentFromDb));
            //student.StudentId = studentFromDb.StudentId;
            //student.Password = studentFromDb.Password;
            //_appDbContext.Entry(student).State = EntityState.Modified;

            _appDbContext.Update(student);
            _appDbContext.SaveChanges();
        }
        public bool StudentExist(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return _appDbContext.Students.Any(s => s.StudentId == studentId);
        }

        public Student GetStudentByEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(nameof(email));
            }

            email = email.Trim();
            Student student = _appDbContext.Students.FirstOrDefault(s => s.Email == email);
            if (student == null)
            { return null; }
            return student;
        }
    }
}
