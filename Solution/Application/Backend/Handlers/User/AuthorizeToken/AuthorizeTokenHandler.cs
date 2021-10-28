using System.Threading.Tasks;
using SmartLock.Context;
using SmartLock.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace SmartLock.Handler.Users.AuthorizeTokenHandler
{
    public class AuthorizeTokenHandler : IAuthorizeTokenHandler
    {
        private DatabaseContext databaseContext;

        public AuthorizeTokenHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Task<bool> Handel(AuthorizeTokenCommand value)
        {
            
        }
    }
}