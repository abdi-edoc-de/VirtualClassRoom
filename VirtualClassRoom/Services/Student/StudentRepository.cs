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
        public async Task<Student> AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            Student student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.StudentId == studentId) ??
                throw new ArgumentNullException(nameof(student));
            _appDbContext.Students.Remove(student);
            await _appDbContext.SaveChangesAsync();
            return student;

        }

        public async Task<Student> FindStudent(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(email));
            }
            email = email.Trim();
            password = password.Trim();
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);
            if (student != null && BCrypt.Net.BCrypt.Verify(password, student.Password))
            {
                return student;
            }
            return null;


        }

        public async Task<Student> GetStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return await _appDbContext.Students.FindAsync(studentId);


        }

        public async Task<Student> UpdateStudent(Guid studentId, Student student)
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
            await _appDbContext.SaveChangesAsync();
            return student;
        }
        public async Task<bool> StudentExist(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return await _appDbContext.Students.AnyAsync(s => s.StudentId == studentId);
        }

        public async Task<Student> GetStudentByEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(nameof(email));
            }

            email = email.Trim();
            var student = await _appDbContext.Students.FirstOrDefaultAsync(s => s.Email == email);

            return student;
        }

        public bool StudentExistByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            email = email.Trim();
            return  _appDbContext.Students.Any(s=>s.Email==email);
        }

        public bool StudentExistNoneAsync(Guid studentId)
        {

            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }
            return _appDbContext.Students.Any(s => s.StudentId == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudentByEmail(IEnumerable<string> emails)
        {
            foreach(var email in emails)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new ArgumentNullException(nameof(email));
                }
            }
            return await _appDbContext.Students.Where(s => emails.Contains(s.Email)).ToListAsync();
        }

        public Student FindStudentNonAsync(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(email));
            }
            email = email.Trim();
            password = password.Trim();
            var student =  _appDbContext.Students.FirstOrDefault(s => s.Email == email);
            if (student != null && BCrypt.Net.BCrypt.Verify(password, student.Password))
            {
                return student;
            }
            return null;

        }
    }
}
