using System;
using SmartLock.Models.User;
using SmartLock.Context;

namespace SmartLock.Handler.User.Logout
{
    public class LogoutHandler : ILogoutHandler
    {
        private DatabaseContext databaseContext;
        public LogoutHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public bool Handel(string shaID)
        {
            throw new Exception("Not implemented");
        }
    }
}