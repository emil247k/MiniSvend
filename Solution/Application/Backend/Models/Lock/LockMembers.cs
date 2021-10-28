using SmartLock.Models.Users;
namespace SmartLock.Models.Locks
{
    public class LockMembers : DbModel
    {
        public User User {get; set;}

        public LockAccessLevel Level {get; set;}
    }
}