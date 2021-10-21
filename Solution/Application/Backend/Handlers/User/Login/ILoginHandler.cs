using System;
using SmartLock.Models.User;
using System.Threading.Tasks;

namespace SmartLock.Handler.User.Login
{
    public interface ILoginHandler : IHandler<Task<string>, LoginCredentials>
    {

    }
}