using System.Collections.Generic;
using System.Threading.Tasks;
using SmartLock.Commands.Locks;
using SmartLock.Models.Locks;
using SmartLock.Handler.Locks;

namespace SmartLock.Services.Locks
{
    public class LockService : ILockService
    {
        private ILockAddAccessHandler lockAddAccessHandler;
        private ILockDetailsHandler lockDetailsHandler;
        private ILockRemoveAccessHandler lockRemoveAccessHandler;
        private INewLockHandler newLockHandler;
        private IUpdateLockStateHandler updateLockStateHandler;
        private IUserLocksHandler userLocksHandler;

        public LockService(
            ILockAddAccessHandler lockAddAccessHandler,
            ILockDetailsHandler lockDetailsHandler,
            ILockRemoveAccessHandler lockRemoveAccessHandler,
            INewLockHandler newLockHandler,
            IUpdateLockStateHandler updateLockStateHandler,
            IUserLocksHandler userLocksHandler)
        {
            this.lockAddAccessHandler = lockAddAccessHandler;
            this.lockDetailsHandler = lockDetailsHandler;
            this.lockRemoveAccessHandler = lockRemoveAccessHandler;
            this.newLockHandler = newLockHandler;
            this.updateLockStateHandler = updateLockStateHandler;
            this.userLocksHandler = userLocksHandler;
        }

        public async Task<bool> AddAccess(LockAddAccessCommand command)
        {
            return await lockAddAccessHandler.Handel(command);
        }

        public async Task<bool> AddNew(NewLockCommand command)
        {
            return await newLockHandler.Handel(command);
        }

        public async Task<LockDetails> GetDetails(long id)
        {
            return await lockDetailsHandler.Handel(id);
        }

        public async Task<IEnumerable<LockDetails>> GetAll()
        {
            return await userLocksHandler.Handel();
        }

        public async Task<bool> UpdateState(UpdateLockStateCommand command)
        {
            return await updateLockStateHandler.Handel(command);
        }

        public async Task<bool> RemoveAccess(LockRemoveAccessCommand command)
        {
            return await lockRemoveAccessHandler.Handel(command);
        }
    }
}