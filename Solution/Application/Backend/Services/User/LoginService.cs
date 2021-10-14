using SmartLock.Handler.User.Login;
using SmartLock.Handler.User.Logout;
using SmartLock.Handler.User.Signup;
using SmartLock.Models.User;

namespace SmartLock.Services.User
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

        public string Login (LoginCredentials credentials)
        {
            throw new System.Exception("Not implemented");
        }

        public bool Logout (string shaID)
        {
            throw new System.Exception("Not implemented");
        }

        public bool Signup (UserDetails userDetails)
        {
            throw new System.Exception("Not implemented");
        }
    }
}