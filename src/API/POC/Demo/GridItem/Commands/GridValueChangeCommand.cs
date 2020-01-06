using CQRS.Commands;
using CQRS.Interfaces;
using System;
using System.Text;

namespace Demo.GridItem.Commands
{
    public class GridValueChangeCommand : ICommand<Result>
    {
        public int AgregateId { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Guid Id { get; set; }            
    }
}
