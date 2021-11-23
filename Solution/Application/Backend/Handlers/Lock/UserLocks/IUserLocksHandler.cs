using System.Collections.Generic;
using SmartLock.Models.Locks;
using System.Threading.Tasks;

namespace SmartLock.Handler.Locks
{
    public interface IUserLocksHandler : IHandler<Task<IEnumerable<LockDetails>>>
    {

    }
}