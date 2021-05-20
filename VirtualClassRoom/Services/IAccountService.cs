using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Services

{
    public interface IAccountService
    {
        public IEnumerable<string> Authenticate(string username, string password);
        string Decrypt(string authHeader);
        string HashPassword(string Password);
        bool VerifyPassword(string Password, string hashedPassword);
    }
}
