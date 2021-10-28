using SmartLock.Commands.Locks;
using SmartLock.Context;
using SmartLock.Models.Locks;
using SmartLock.Models.Users;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SmartLock.Handler.locks.NewLockHandler
{
    public class NewLockHandler : INewLockHandler
    {
        private ISessionContext sessionContext;
        private DatabaseContext databaseContext;
        public NewLockHandler(
            DatabaseContext databaseContext,
            ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }

        public async Task<bool> Handel(NewLockCommand value)
        {
            var alreadeyExistes = await databaseContext.Set<Lock>().AnyAsync(x => x.RemoteIp == value.RemoteIp);

            if(alreadeyExistes)
            {
                throw new System.Exception("Lock already exist try reseting the lock");
            }

            var sessionToken = sessionContext.getToken("token");
            var currentUser = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == sessionToken);

            await databaseContext.Set<Lock>().AddAsync(new Lock(){
                Name = value.Name,
                Description = value.Description,
                RemoteIp = value.RemoteIp,
                Members = new List<LockMembers>(){
                    new LockMembers() {
                        User = currentUser,
                        Level = LockAccessLevel.Ownere
                    },
                },
            });
            await databaseContext.SaveChangesAsync();

            return true;
        }
    }
}