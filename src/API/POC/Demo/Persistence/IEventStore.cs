using CQRS.Events;
using Demo.Domain.Objects;
using System.Threading.Tasks;

namespace Demo.Persistence
{
    public interface IEventStore
    {
        Task<EventData<T>> Add<T>(EventData<T> @event) where T : IEvent;
    }
}