using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CQRS.Queries
{
    public class QueryBus : IQueryBus
    {
        private readonly IMediator mediator;

        public QueryBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<Response> Send<Command, Response>(Command query)
            where Command : IQuery<Response>
            where Response : IResponse
        {
            return this.mediator.Send(query);
        }
    }
}
