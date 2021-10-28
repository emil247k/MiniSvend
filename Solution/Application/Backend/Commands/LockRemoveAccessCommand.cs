namespace SmartLock.Commands.Locks
{
    public class LockRemoveAccessCommand
    {
        public long UserId {get; set;}

        public long LockId {get; set;}
    }
}