using System.Threading.Tasks;

namespace SmartLock.Handler.Users
{
    public interface ILogoutHandler : IHandler<Task<bool>, string>
    {

    }
}