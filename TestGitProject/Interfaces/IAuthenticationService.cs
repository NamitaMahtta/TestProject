using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestGitProject.Interfaces
{
    public interface IAuthenticationService
    {
        Task Register(string phoneNumber);

        Task<HttpStatusCode> AuthorizeUser(string phoneNumber, string verificationCode);
    }
}
