using System.Threading.Tasks;
using SmartLock.Context;
using SmartLock.Models.Locks;
using SmartLock.Models.Users;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.Locks
{
    public class LockAddAccessHandler : ILockAddAccessHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public LockAddAccessHandler(
            DatabaseContext databaseContext,
            ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }
        public async Task<bool> Handel(LockAddAccessCommand value)
        {
            var sessionToken = sessionContext.getToken("token");
            var currentUser = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == sessionToken);
            var updateUser = await databaseContext.Set<User>().SingleAsync(x => x.Id == value.UserId);
            var dbLock = await databaseContext.Set<Lock>().SingleAsync(x => x.Id == value.LockId);
            var currentUserAccessLevel = dbLock.Members.Single(x => x.User.Id == currentUser.Id).Level;
            var updateUserAccessLevel = dbLock.Members.SingleOrDefault(x => x.User.Id == updateUser.Id).Level;

            if(currentUserAccessLevel <= updateUserAccessLevel)
            {
                throw new System.Exception("Unable to change access level of user with same or lower access level");
            }
            if(currentUserAccessLevel <= value.AccessLevel)
            {
                throw new System.Exception("Unable to update to higher or same access level as you");
            }

            dbLock.Members.Append(
                new LockMembers()
                {
                    User = updateUser,
                    Level = value.AccessLevel
                });

            databaseContext.SaveChanges();
            return true;
        }
    }
}