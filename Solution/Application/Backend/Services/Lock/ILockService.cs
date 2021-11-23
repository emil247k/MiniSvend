using SmartLock.Models.Locks;
using SmartLock.Commands.Locks;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SmartLock.Services.Locks
{
    public interface ILockService
    {
        Task<bool> AddAccess (LockAddAccessCommand command);
        Task<LockDetails> GetDetails (long id);
        Task<bool> RemoveAccess (LockRemoveAccessCommand command);
        Task<bool> AddNew (NewLockCommand command);
        Task<bool> UpdateState (UpdateLockStateCommand command);
        Task<IEnumerable<LockDetails>> GetAll ();
    }
}