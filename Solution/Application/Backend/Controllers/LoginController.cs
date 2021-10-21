using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartLock.Models.User;
using SmartLock.Context;
using Microsoft.EntityFrameworkCore;
using SmartLock.Services.User;

namespace SmartLock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;
        private ILoginService loginService;
        public LoginController(
            ILogger<LoginController> logger,
            ILoginService loginService)
        {
            this.logger = logger;
            this.loginService = loginService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials credentials)
        {
            return Ok(await loginService.Login(credentials));
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserDetails details)
        {
            return Ok(await loginService.Signup(details));
        }

        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> Logout(string token)
        {
            return Ok(await loginService.Logout(token));
        }
    }
}