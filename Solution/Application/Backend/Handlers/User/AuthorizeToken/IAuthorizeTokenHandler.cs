using System.Threading.Tasks;
using SmartLock.Models.Users;

namespace SmartLock.Handler.Users.AuthorizeTokenHandler
{
    public interface IAuthorizeTokenHandler : IHandler<Task<bool>, AuthorizeTokenCommand>
    {
    }
}