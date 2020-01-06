using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.GridItem.Events
{
    public class ValueChangedEvent : IEvent
    {
        public string PropertyName { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public Type AgregateType { get; set; }
        public int AgregateId { get; set; }
    }
}
