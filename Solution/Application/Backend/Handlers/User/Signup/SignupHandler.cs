using System;
using SmartLock.Models.User;
using SmartLock.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SmartLock.Handler.User.Signup
{
    public class SignupHandler : ISignupHandler
    {
        private DatabaseContext databaseContext;
        public SignupHandler(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<bool> Handel(UserDetails details)
        {
            bool alreadyExists = await databaseContext.Set<SmartLock.Models.User.User>()
                .AnyAsync(x => x.Username == details.Username ||
                    x.Email == details.Email);

            if(alreadyExists)
            {
                throw new System.Exception("There already exists and account with that username or email");
            }

            SmartLock.Models.User.User newUser = new SmartLock.Models.User.User
            {
                Name = details.Name,
                LastName = details.LastName,
                Email = details.Email,
                Username = details.Username,
                ShaID = details.ShaID
            };

            await databaseContext.Set<SmartLock.Models.User.User>().AddAsync(newUser);
            return await databaseContext.SaveChangesAsync() > 0;
        }
    }
}