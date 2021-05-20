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

        public IEnumerable<string> Authenticate(string username, string password)
        {
            Student student = _studentRepository.FindStudent(username, password);
            string role = "Student";
            if (student==null)
            {
                role = "Instructor";
                Instructor instructor = _instructprRepository.FindInstructor(username, password);
                if (instructor == null)
                {
                    return null;
                }
            }            
            return new List<string> { _jwtAuthenticationManager.Authenticate(username, role),role };
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
