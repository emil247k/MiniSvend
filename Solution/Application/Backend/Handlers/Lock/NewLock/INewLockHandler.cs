using SmartLock.Commands.Locks;
using System.Threading.Tasks;

namespace SmartLock.Handler.Locks
{
    public interface INewLockHandler : IHandler<Task<bool>, NewLockCommand>
    {
         
    }
}