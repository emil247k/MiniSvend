using SmartLock.Models.User;
using System.Threading.Tasks;

namespace SmartLock.Handler.User.Logout
{
    public interface ILogoutHandler : IHandler<Task<bool>, string>
    {

    }
}