using System;
using SmartLock.Models.User;
using System.Threading.Tasks;

namespace SmartLock.Services.User
{
    public interface ILoginService
    {
        Task<string> Login (LoginCredentials credentials);

        Task<bool> Logout (string shaID);

        Task<bool> Signup (UserDetails userDetails);
    }
}