namespace SmartLock.Models.Locks
{
    public class LockDetails
    {
        public long Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public LockState State {get; set;}
    }
}