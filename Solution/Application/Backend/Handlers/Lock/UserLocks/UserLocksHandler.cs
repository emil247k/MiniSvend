using System.Collections.Generic;
using System.Threading.Tasks;
using SmartLock.Models.Locks;
using SmartLock.Context;
using SmartLock.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SmartLock.Handler.locks.UserLocksHandler
{
    public class UserLocksHandler : IUserLocksHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public UserLocksHandler(
            DatabaseContext databaseContext,
            ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }

        public async Task<IEnumerable<LockDetails>> Handel()
        {
            var sessionToken = sessionContext.getToken("token");
            var currentUser = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == sessionToken);
            var locks = await databaseContext.Set<Lock>()
            .Include(x => x.Members)
            .ThenInclude( x => x.User)
            .Where(x => x.Members.Any(x => x.User.Id == currentUser.Id))
            .Select(x => new LockDetails(){
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                State = x.State
            }).ToListAsync();

            return locks;
        }
    }
}