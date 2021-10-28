using SmartLock.Commands.Locks;
using System.Threading.Tasks;

namespace SmartLock.Handler.locks.NewLockHandler
{
    public interface INewLockHandler : IHandler<Task<bool>, NewLockCommand>
    {
         
    }
}