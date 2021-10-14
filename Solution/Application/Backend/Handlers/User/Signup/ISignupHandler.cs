using SmartLock.Models.User;

namespace SmartLock.Handler.User.Signup
{
    public interface ISignupHandler : IHandler<bool, UserDetails>
    {

    }
}