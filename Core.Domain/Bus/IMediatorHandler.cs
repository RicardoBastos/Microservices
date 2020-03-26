using Core.Domain.Events;
using System.Threading.Tasks;

namespace Core.Domain.Bus
{
    public interface IMediatorHandler
    {
        Task EnviarCommand<T>(T command) where T : Command;
        Task EnviarEvent<T>(T @event) where T : Event;
    }
}
