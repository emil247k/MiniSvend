using SmartLock.Handler.Users;
using SmartLock.Models.Users;
using System.Threading.Tasks;

namespace SmartLock.Services.Users
{
    public class LoginService: ILoginService
    {
        private ILoginHandler loginHandler;
        private ILogoutHandler logoutHandler;
        private ISignupHandler signupHandler;
        public LoginService(
            ILoginHandler loginHandler,
            ILogoutHandler logoutHandler,
            ISignupHandler signupHandler)
        {
            this.loginHandler = loginHandler;
            this.logoutHandler = logoutHandler;
            this.signupHandler = signupHandler;
        }

        public async Task<string> Login (LoginCredentials credentials)
        {
            return await loginHandler.Handel(credentials);
        }

        public async Task<bool> Logout (string shaID)
        {
            return await logoutHandler.Handel(shaID);
        }

        public async Task<bool> Signup (UserDetails userDetails)
        {
            return await signupHandler.Handel(userDetails);
        }
    }
}