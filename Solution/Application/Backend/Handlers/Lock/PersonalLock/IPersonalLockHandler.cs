using System.Threading.Tasks;
using SmartLock.Commands.Locks;

namespace SmartLock.Handler.locks.PersonalLockHandler
{
    public interface IPersonalLockHandler : IHandler<Task<bool>, PersonalLockCommand>
    {

    }
}