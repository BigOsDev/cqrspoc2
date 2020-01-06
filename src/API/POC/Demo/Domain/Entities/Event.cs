using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Domain.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int Caller { get; set; }
        public string CallerName { get; set; }
        public string EventType { get; set; }
        public string AgregateType { get; set; }
        public int AgregateId { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }

        //TODO: remove
        public DateTime? ProcessedAt { get; set; }
        //TODO: remove
        public bool Succeed { get; set; }
    }
}
