using CQRS.Events;
using Demo.GridItem.Events;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using POC.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Notification.EventHandlers
{
    public class ValueChangedEventHandler : IEventHandler<ValueChangedEvent>
    {
        private readonly ILogger logger;
        private IHubContext<EventNotificationsHub> hubContext;

        public ValueChangedEventHandler(ILogger<ValueChangedEventHandler> logger, IHubContext<EventNotificationsHub> hubContext)
        {
            this.logger = logger;
            this.hubContext = hubContext;
        }

        public async Task Handle(ValueChangedEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                await hubContext.Clients.All.SendAsync("SendNotification", notification);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "ValueChangedEventHandler error");
            }
        }
    }
}
