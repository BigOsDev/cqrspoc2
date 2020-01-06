using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public interface ICommandBus
    {
        Task<Response> Send<Command, Response>(Command query) where Command : ICommand<Response> where Response : IResponse;
    }
}
