using SmartLock.Models.Locks;

namespace SmartLock.Commands.Locks
{
    public class UpdateLockStateCommand
    {
        public long LockId {get; set;}

        public LockState State {get; set;}
    }
}