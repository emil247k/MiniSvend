using System.Collections.Generic;
using SmartLock.Models.Locks;
using System.Threading.Tasks;

namespace SmartLock.Handler.locks.UserLocksHandler
{
    public interface IUserLocksHandler : IHandler<Task<IEnumerable<LockDetails>>>
    {

    }
}