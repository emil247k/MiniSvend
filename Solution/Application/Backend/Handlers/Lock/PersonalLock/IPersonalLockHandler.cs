using System.Threading.Tasks;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.Locks
{
    public interface IUpdateLockStateHandler : IHandler<Task<bool>, UpdateLockStateCommand>
    {

    }
}