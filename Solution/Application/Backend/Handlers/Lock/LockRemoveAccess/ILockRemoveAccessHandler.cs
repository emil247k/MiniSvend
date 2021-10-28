using System.Threading.Tasks;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.locks.LockRemoveAccessHandler
{
    public interface ILockRemoveAccessHandler : IHandler<Task<bool>, LockRemoveAccessCommand>
    {
        
    }
}