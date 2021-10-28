using SmartLock.Models.Locks;

namespace SmartLock.Commands.Locks
{
    public class LockAddAccessCommand
    {
        public long UserId {get; set;}

        public long LockId {get; set;}

        public LockAccessLevel AccessLevel {get; set;}
    }
}