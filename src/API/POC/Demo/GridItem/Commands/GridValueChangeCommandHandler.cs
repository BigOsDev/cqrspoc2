using CQRS.Commands;
using CQRS.Events;
using CQRS.Interfaces;
using Demo.Domain.Entities;
using Demo.Domain.Objects;
using Demo.GridItem.Events;
using Demo.Infrastructure;
using Demo.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.GridItem.Commands
{
    public class GridValueChangeCommandHandler : ICommandHandler<GridValueChangeCommand, Result>
    {
        private readonly DemoContext context;
        private readonly IEventBus eventBus;
        private readonly IEventStore eventStore;



        public GridValueChangeCommandHandler(DemoContext context, IEventBus eventBus, IEventStore eventStore)
        {
            this.context = context;
            this.eventBus = eventBus;
            this.eventStore = eventStore;
        }

        public async Task<Result> Handle(GridValueChangeCommand request, CancellationToken cancellationToken)
        {
            //TODO: Add transaction
            await SetProperty(request.AgregateId, request.PropertyName, request.NewValue, request.OldValue);
            var newEvent = new ValueChangedEvent
            {
                PropertyName = request.PropertyName,
                NewValue = request.NewValue,
                OldValue = request.OldValue,
                AgregateId = request.AgregateId,
                AgregateType = typeof(Item),
            };

            await eventStore.Add(new EventData<ValueChangedEvent>
            {
                AgregateId = newEvent.AgregateId,
                AgregateType = newEvent.AgregateType,
                Caller = 99999999,
                CallerName = "test",
                CreatedAt = DateTime.Now,
                Data = newEvent
            });

            await context.SaveChangesAsync();

            await eventBus.Publish(newEvent);
            return await Task.FromResult(Result.Success());
        }

        private async Task SetProperty(int id, string propertyName, object newValue, object oldValue)
        {
            var entity = context.Items.SingleOrDefault(x => x.Id == id);

            switch (propertyName)
            {
                case nameof(entity.Price):
                    {
                        if (entity.Price == (decimal)oldValue)
                        {
                            entity.Price = (decimal)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Rate):
                    {
                        if (entity.Rate == (decimal)oldValue)
                        {
                            entity.Rate = (decimal)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.RestaurantName):
                    {
                        if (entity.RestaurantName == (string)oldValue)
                        {
                            entity.RestaurantName = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Title):
                    {
                        if (entity.Title == (string)oldValue)
                        {
                            entity.Title = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Votes):
                    {
                        if (entity.Votes == (int)oldValue)
                        {
                            entity.Votes = (int)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Another1):
                    {
                        if (entity.Another1 == (string)oldValue)
                        {
                            entity.Another1 = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Another2):
                    {
                        if (entity.Another2 == (string)oldValue)
                        {
                            entity.Another2 = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Another3):
                    {
                        if (entity.Another3 == (string)oldValue)
                        {
                            entity.Another3 = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Another4):
                    {
                        if (entity.Another4 == (string)oldValue)
                        {
                            entity.Another4 = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                case nameof(entity.Description):
                    {
                        if (entity.Description == (string)oldValue)
                        {
                            entity.Description = (string)newValue;
                        }
                        else
                        {
                            throw new Exception("Value already changed");
                        }
                        break;
                    }
                default:
                    throw new Exception("Not supported for type: " + propertyName);

            }

            await context.SaveChangesAsync();
        }

    }
}
