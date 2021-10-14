using System;
using SmartLock.Models.User;
using SmartLock.Context;

namespace SmartLock.Handler.User.Login
{
    public class LoginHandler : ILoginHandler
    {
        private DatabaseContext databaseContext;
        public LoginHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public string Handel(LoginCredentials credential)
        {
            throw new Exception("Not implemented");
        }
    }
}