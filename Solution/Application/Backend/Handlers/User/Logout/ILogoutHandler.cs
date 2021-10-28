using System.Threading.Tasks;

namespace SmartLock.Handler.Users.Logout
{
    public interface ILogoutHandler : IHandler<Task<bool>, string>
    {

    }
}