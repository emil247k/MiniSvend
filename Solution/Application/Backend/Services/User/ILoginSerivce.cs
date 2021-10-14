using System;
using SmartLock.Models.User;

namespace SmartLock.Services.User
{
    public interface ILoginService
    {
        string Login (LoginCredentials credentials);

        bool Logout (string shaID);

        bool Signup (UserDetails userDetails);
    }
}