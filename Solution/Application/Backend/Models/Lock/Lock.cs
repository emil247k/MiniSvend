using SmartLock.Models.Users;
using System.Collections.Generic;

namespace SmartLock.Models.Locks
{
    public class Lock : DbModel
    {
        public IEnumerable<LockMembers> Members {get; set;}

        public LockState State {get; set;}

        public string Name {get; set;}

        public string Description {get; set;}

        public string RemoteIp {get; set;}

    }
}