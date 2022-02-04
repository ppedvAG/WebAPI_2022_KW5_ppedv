#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTBearerTokenClientSample.Models
{
    public class LoginCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginCredentialsResponse
    {
        public string Token { get; set; }
        public string Message { get; set; }
    }

}
