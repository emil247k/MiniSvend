using System;
using SmartLock.Models.Users;
using SmartLock.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace SmartLock.Handler.Users
{
    public class LoginHandler : ILoginHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public LoginHandler(DatabaseContext databaseContext,
        ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }

        public async Task<string> Handel(LoginCredentials credentials)
        {
            User user = await databaseContext.Set<User>()
                .FirstAsync(x => x.Username == credentials.Username && x.ShaID == credentials.ShaID);

            if (user != default)
            {
                user.LastLogin = DateTime.Now;
                using (SHA256 sha256Hasher = SHA256.Create())  
                {
                    byte[] hash = sha256Hasher.ComputeHash(Encoding.UTF8.GetBytes(user.LastLogin + user.ShaID));
                    sessionContext.SetToken("token", hash);
                    string token = String.Join("", hash.Select(x => String.Format("{0:x2}",x)));
                    user.ActivToken = token;
                    await databaseContext.SaveChangesAsync();
                    return token;
                }
            }
            throw new System.Exception("Unauthorized");
        }
    }
}