using SmartLock.Models.Users;
using System.Threading.Tasks;

namespace SmartLock.Handler.Users
{
    public interface ISignupHandler : IHandler<Task<bool>, UserDetails>
    {

    }
}