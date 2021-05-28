using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstructorRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public async Task<Instructor> AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));
            }
            _appDbContext.Instructors.Add(instructor);
            await _appDbContext.SaveChangesAsync();
            return instructor;
        }
        public async Task<Instructor> DeleteInstructor(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }
            Instructor instructor = await _appDbContext.Instructors.FirstOrDefaultAsync(s => s.InstructorId == instructorId)
                ?? throw new ArgumentNullException(nameof(instructor));
            _appDbContext.Instructors.Remove(instructor);
            await _appDbContext.SaveChangesAsync();
            return instructor;
        }

        public async Task<Instructor> FindInstructor(string email, string password)
        {
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(nameof(email));
            }
            email = email.Trim();
            password = password.Trim();
            Instructor instructor = await _appDbContext.Instructors.FirstOrDefaultAsync(s => s.Email == email);
            if (instructor != null && BCrypt.Net.BCrypt.Verify(password, instructor.Password))
            {
                return instructor;
            }
            return null;



        }

        //public bool VerifyPassword(string plainPassword, string hashedPassword)
        //{
        //    return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        //}
        public async Task<Instructor> GetInstructor(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }

            return await _appDbContext.Instructors.FindAsync(instructorId);

        }

        public async Task<bool> InstrucotrExist(Guid instructorId)
        {
            if (instructorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instructorId));
            }
            return await _appDbContext.Instructors.AnyAsync(s => s.InstructorId == instructorId);
        }

        public async Task<Instructor> UpdateInstructor(Instructor instructor)
        {

            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));

            }
            _appDbContext.Update(instructor);
            await _appDbContext.SaveChangesAsync();
            return instructor;


        }
        public async Task<Instructor> GetInstructorByEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException(nameof(email));
            }

            email = email.Trim();
            Instructor instructor = await _appDbContext.Instructors.FirstOrDefaultAsync(s => s.Email == email);

            return instructor;
        }
    }
}
