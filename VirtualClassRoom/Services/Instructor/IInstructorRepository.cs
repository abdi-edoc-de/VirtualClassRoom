using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IInstructorRepository
    {
        public Task<bool> InstrucotrExist(Guid instructorId);

        public Task<Instructor> FindInstructor(string email, string password);
        public Task<Instructor> GetInstructor(Guid instructorId);
        public Task<Instructor> UpdateInstructor(Instructor instructor);
        public Task<Instructor> AddInstructor(Instructor instructor);
        public Task<Instructor> DeleteInstructor(Guid instructorId);
        public Task<Instructor> GetInstructorByEmail(string email);


    }
}
