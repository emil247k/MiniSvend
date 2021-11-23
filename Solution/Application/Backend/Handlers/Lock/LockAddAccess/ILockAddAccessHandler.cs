using System.Threading.Tasks;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.Locks
{
    public interface ILockAddAccessHandler : IHandler<Task<bool>, LockAddAccessCommand>
    {
        
    }
}