using System;
using SmartLock.Models.Users;
using System.Threading.Tasks;

namespace SmartLock.Services.Users
{
    public interface ILoginService
    {
        Task<string> Login (LoginCredentials credentials);

        Task<bool> Logout (string shaID);

        Task<bool> Signup (UserDetails userDetails);
    }
}