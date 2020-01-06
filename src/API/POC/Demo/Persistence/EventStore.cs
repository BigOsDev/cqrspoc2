using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Events;
using Demo.Domain.Entities;
using Demo.Domain.Objects;
using Demo.Infrastructure;
using Newtonsoft.Json;

namespace Demo.Persistence
{
    public class EventStore : IEventStore
    {
        private readonly DemoContext context;

        public EventStore(DemoContext context, IEventBus eventBus)
        {
            this.context = context;
        }


        public async Task<EventData<T>> Add<T>(EventData<T> @event) where T : IEvent
        {
            var entity = new Event()
            {
                AgregateId = @event.AgregateId,
                AgregateType = @event.AgregateType.ToString(),
                Caller = @event.Caller,
                CallerName = @event.CallerName,
                CreatedAt = @event.CreatedAt,
                EventType = @event.Data.GetType().ToString(),
                Data = JsonConvert.SerializeObject(@event.Data),                      
                
            };
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            @event.Id = entity.Id;
            return @event;
        }
    }
}
