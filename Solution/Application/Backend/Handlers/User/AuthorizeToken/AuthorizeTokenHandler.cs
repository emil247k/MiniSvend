using System.Threading.Tasks;
using SmartLock.Context;
using SmartLock.Models.Users;
using SmartLock.Models.Locks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SmartLock.Handler.Users
{
    public class AuthorizeTokenHandler : IAuthorizeTokenHandler
    {
        private DatabaseContext databaseContext;

        public AuthorizeTokenHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<bool> Handel(AuthorizeTokenCommand value)
        {
            var user = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == value.Token);
            var dblock = await databaseContext.Set<Lock>()
            .Include(x => x.Members)
            .ThenInclude(x => x.User)
            .SingleAsync(x => x.Id == value.LockId);
            var userLevel = dblock.Members.Single(x => x.User.Id == user.Id).Level;

            switch(userLevel)
            {
                case LockAccessLevel.Geust:
                    if(AuthorizeCallType.Offline == value.CallType)
                    {
                        
                    }
                    break;
                case LockAccessLevel.Admin: 
                    break;
                case LockAccessLevel.Ownere: 
                    break;
            }
            return true;
        }
    }
}