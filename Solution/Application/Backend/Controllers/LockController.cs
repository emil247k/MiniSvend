using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartLock.Models.Users;
using SmartLock.Controllers;
using SmartLock.Services.Locks;
using SmartLock.Commands.Locks;
using System.Collections.Generic;
using SmartLock.Models.Locks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LockController : ControllerBase
    {
        private ILockService lockSerivice;

        public LockController(
            ILockService lockSerivice)
        {
            this.lockSerivice = lockSerivice;
        }
        
        [Route("AddAccess")]
        [HttpPost]
        public async Task<bool> AddAccess(LockAddAccessCommand command)
        {
            return await lockSerivice.AddAccess(command);
        }

        [Route("RemoveAccess")]
        [HttpPost]
        public async Task<bool> RemoveAccess(LockRemoveAccessCommand command)
        {
            return await lockSerivice.RemoveAccess(command);
        }

        [Route("Details")]
        [HttpGet]
        public async Task<LockDetails> GetDetails(long id)
        {
            return await lockSerivice.GetDetails(id);
        }

        [Route("AllDetails")]
        [HttpGet]
        public async Task<IEnumerable<LockDetails>> GetAll()
        {
            return await lockSerivice.GetAll();
        }

        [Route("UpdateState")]
        [HttpPost]
        public async Task<bool> UpdateState(UpdateLockStateCommand command)
        {
            return await lockSerivice.UpdateState(command);
        }

        [Route("AddNew")]
        [HttpPost]
        public async Task<bool> AddNew(NewLockCommand command)
        {
            return await lockSerivice.AddNew(command);
        }
    }
}