using SmartLock.Handler;
using SmartLock.Models.Locks;
using System.Threading.Tasks;

namespace SmartLock.Handler.Locks
{
    public interface ILockDetailsHandler : IHandler<Task<LockDetails>,long>
    {
         
    }
}