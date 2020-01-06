using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public interface ICommandHandler<in Command, Response> : IRequestHandler<Command, Response> where Command : ICommand<Response> where Response : IResponse
    {
    }
}
