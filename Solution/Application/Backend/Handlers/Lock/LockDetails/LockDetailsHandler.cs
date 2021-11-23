using System.Threading.Tasks;
using SmartLock.Models.Locks;
using SmartLock.Context;
using SmartLock.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SmartLock.Handler.Locks
{
    public class LockDetailsHandler : ILockDetailsHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public LockDetailsHandler(
            DatabaseContext databaseContext,
            ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }

        public async Task<LockDetails> Handel(long value)
        {
            var sessionToken = sessionContext.getToken("token");
            var currentUser = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == sessionToken);
            var lockModal = await databaseContext.Set<Lock>().SingleAsync(x => x.Id == value);

            if(lockModal.Members.Any(x => x.User.Id == currentUser.Id))
            {
                throw new System.Exception("You do not have access to this lock");
            }
            
            return new LockDetails {
                Name = lockModal.Name,
                Description = lockModal.Description,
                State = lockModal.State
            };
        }
    }
}