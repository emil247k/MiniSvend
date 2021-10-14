using System;
using SmartLock.Models.User;
using SmartLock.Context;

namespace SmartLock.Handler.User.Signup
{
    public class SignupHandler : ISignupHandler
    {
        private DatabaseContext databaseContext;
        public SignupHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public bool Handel(UserDetails details)
        {
            throw new Exception("Not implemented");
        }
    }
}