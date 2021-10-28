using SmartLock.Context;
using SmartLock.Models.Users;
using SmartLock.Models.Locks;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.locks.PersonalLockHandler
{
    public class PersonalLockHandler : IPersonalLockHandler
    {
        private DatabaseContext databaseContext;
        private ISessionContext sessionContext;
        public PersonalLockHandler(
            DatabaseContext databaseContext,
            ISessionContext sessionContext)
        {
            this.databaseContext = databaseContext;
            this.sessionContext = sessionContext;
        }

        public async Task<bool> Handel(PersonalLockCommand value)
        {
            var sessionToken = sessionContext.getToken("token");
            var currentUser = await databaseContext.Set<User>().SingleAsync(x => x.ActivToken == sessionToken);
            var dblock = await databaseContext.Set<Lock>().SingleAsync(x => x.Id == value.LockId);

            if(!dblock.Members.Any(x => x.User.Id == currentUser.Id))
            {
                throw new System.Exception("You do not have access to this lock");
            }

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            string sendData = $"userToken={sessionToken},";
            StringContent content = new StringContent(sendData);
            HttpResponseMessage response = await client.PostAsync($"{dblock.RemoteIp}?state={value.State}",content);
            if (response.IsSuccessStatusCode)
            {
                string respond = await response.Content.ReadAsStringAsync();
            }
            else
            {
                dblock.State = LockState.Offline;
                await databaseContext.SaveChangesAsync();
                throw new Exception("Unable to connect to lock");
            }

            client.Dispose();
            return true;
        }
    }
}