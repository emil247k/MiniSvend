using System;
using SmartLock.Models.Users;
using SmartLock.Context;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SmartLock.Handler.Users
{
    public class LogoutHandler : ILogoutHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public LogoutHandler(DatabaseContext databaseContext,
        ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }

        public async Task<bool> Handel(string shaID)
        {
            string token = sessionContext.getToken("token");
            User user = await databaseContext.Set<User>()
                .FirstOrDefaultAsync(x => x.ActivToken == token);
            if(user != default)
            {
                user.ActivToken = "";
                databaseContext.SaveChanges();
                sessionContext.RemoveToken("token");
                return true;
            }
            throw new System.Exception("User is already loged out");
        }
    }
}