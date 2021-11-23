using System.Threading.Tasks;
using SmartLock.Context;
using SmartLock.Models.Locks;
using SmartLock.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.Locks
{
    public class LockRemoveAccessHandler : ILockRemoveAccessHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public LockRemoveAccessHandler(
            DatabaseContext databaseContext,
            ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }
        public async Task<bool> Handel(LockRemoveAccessCommand value)
        {
            var sessionToken = sessionContext.getToken("token");
            var currentUser = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == sessionToken);
            var updateUser = await databaseContext.Set<User>().SingleAsync(x => x.Id == value.UserId);
            var dbLock = await databaseContext.Set<Lock>().SingleAsync(x => x.Id == value.LockId);
            var currentUserAccessLevel = dbLock.Members.Single(x => x.User.Id == currentUser.Id).Level;
            var updateUserAccessLevel = dbLock.Members.SingleOrDefault(x => x.User.Id == updateUser.Id).Level;

            if(currentUserAccessLevel <= updateUserAccessLevel)
            {
                throw new System.Exception("Unable to remove user of higher or same access level");
            }

            dbLock.Members = dbLock.Members.Where(x => x.User.Id != value.UserId);
            databaseContext.SaveChanges();
            return true;
        }
    }
}