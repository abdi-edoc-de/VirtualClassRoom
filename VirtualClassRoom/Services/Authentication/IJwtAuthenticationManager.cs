using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualClassRoom.Services

{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
        string Decrypt(string authHeader);
    }
}
