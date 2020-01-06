using CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Objects
{
    public  class EventData<T> where T : IEvent
    {
        public int Id { get; set; }
        public int Caller { get; set; }
        public string CallerName { get; set; }
        public Type AgregateType { get; set; }
        public int AgregateId { get; set; }
        public IEvent Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
        public bool Succeed { get; set; }
    }
}
