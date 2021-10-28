using SmartLock.Models.Locks;

namespace SmartLock.Models.Users
{
    public class AuthorizeTokenCommand
    {
        public string Token {get; set;}

        public AuthorizeTokenCommand CallType {get; set;}

        public long LockId {get; set;}
    }
}