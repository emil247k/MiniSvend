using SmartLock.Models.Users;
using System.Threading.Tasks;

namespace SmartLock.Handler.Users.Signup
{
    public interface ISignupHandler : IHandler<Task<bool>, UserDetails>
    {

    }
}