using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Events
{
    public interface IEvent : INotification
    {
    }
}
