using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartLock.Models.User;
using SmartLock.Context;
using Microsoft.EntityFrameworkCore;

namespace SmartLock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;
        private DatabaseContext databaseContext;
        public LoginController(
            ILogger<LoginController> logger,
            DatabaseContext databaseContext)
        {
            this.logger = logger;
            this.databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCredentials credentials)
        {
            var a = databaseContext.Set<User>().Add(new User(){
                Username= "asd",
                Name="asd",
                LastName="asd",
                Email="Email",
                ShaID="ShaID"
            });

            return Ok("somthing");
        }
    }
}