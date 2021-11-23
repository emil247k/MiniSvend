using System.Threading.Tasks;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.Locks
{
    public interface ILockRemoveAccessHandler : IHandler<Task<bool>, LockRemoveAccessCommand>
    {
        
    }
}