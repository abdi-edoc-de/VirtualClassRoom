using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services

{
    public class AccountService : IAccountService
    {       
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IInstructorRepository _instructprRepository;



        public AccountService(IStudentRepository studentRepository,
            IInstructorRepository instructorRepository,
            IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _studentRepository = studentRepository;
            _instructprRepository = instructorRepository;
        }

        public async Task<IEnumerable<string>> Authenticate(string username, string password)
        {
            Student student = await _studentRepository.FindStudent(username, password);
            Guid id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b");
            string role = "Student";
            if (student != null)
            {
                id = student.StudentId;
            }
            if (student == null)
            {
                role = "Instructor";
                Instructor instructor = await _instructprRepository.FindInstructor(username, password);

                if (instructor == null)
                {
                    return null;
                }
                else
                {
                    id = instructor.InstructorId;
                }

            }
            return new List<string> { _jwtAuthenticationManager.Authenticate(id.ToString(), role),role };
        }

        //Decrypts the bearer token from the authentication header
        public string Decrypt(string authHeader)
        {
            return _jwtAuthenticationManager.Decrypt(authHeader);
        }

        public string HashPassword(string Password)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string Password, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        //public string HashPassword(string password)
        //{
        //    //return BCrypt.Net.BCrypt.HashPassword(password);
        //}

        //public bool VerifyPassword(string plainPassword,string hashedPassword)
        //{
        //    return BCrypt.Net.BCrypt.Verify(plainPassword,hashedPassword);
        //}

    }
}
