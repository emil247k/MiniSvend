using System.Threading.Tasks;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.locks.LockAddAccessHandler
{
    public interface ILockAddAccessHandler : IHandler<Task<bool>, LockAddAccessCommand>
    {
        
    }
}