using SmartLock.Models.User;
using System.Threading.Tasks;

namespace SmartLock.Handler.User.Signup
{
    public interface ISignupHandler : IHandler<Task<bool>, UserDetails>
    {

    }
}