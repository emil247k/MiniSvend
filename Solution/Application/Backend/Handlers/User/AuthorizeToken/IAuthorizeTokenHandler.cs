using System.Threading.Tasks;
using SmartLock.Models.Users;

namespace SmartLock.Handler.Users
{
    public interface IAuthorizeTokenHandler : IHandler<Task<bool>, AuthorizeTokenCommand>
    {
    }
}