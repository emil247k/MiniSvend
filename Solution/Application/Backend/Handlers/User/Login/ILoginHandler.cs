using System;
using SmartLock.Models.Users;
using System.Threading.Tasks;

namespace SmartLock.Handler.Users
{
    public interface ILoginHandler : IHandler<Task<string>, LoginCredentials>
    {

    }
}