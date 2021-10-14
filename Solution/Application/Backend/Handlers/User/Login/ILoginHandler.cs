using System;
using SmartLock.Models.User;

namespace SmartLock.Handler.User.Login
{
    public interface ILoginHandler : IHandler<string, LoginCredentials>
    {

    }
}