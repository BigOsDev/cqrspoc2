using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CQRS.Commands
{
    public class CommandBus : ICommandBus
    {
        private readonly IMediator mediator;

        public CommandBus(IMediator mediator)
        {
            this.mediator = mediator;
        }
              
        public Task<Response> Send<Command, Response>(Command query)
            where Command : ICommand<Response>
            where Response : IResponse
        {
            return this.mediator.Send(query);
        }
    }
}
