using CQRS.Events;
using Demo.Domain.Objects;
using Demo.Infrastructure;
using Demo.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.GridItem.Events
{
    //public class ValueChangedEventHandler : IEventHandler<ValueChangedEvent>
    //{
    //    private readonly ILogger logger;

    //    public ValueChangedEventHandler(ILogger<ValueChangedEventHandler> logger)
    //    {
    //        this.logger = logger;
    //    }

    //    public async Task Handle(ValueChangedEvent notification, CancellationToken cancellationToken)
    //    {
    //        logger.LogInformation("Test");
    //    }
    //}
}
