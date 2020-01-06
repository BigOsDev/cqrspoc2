using CQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Commands
{
    public interface ICommand<out Response> : IRequest<Response> where Response : IResponse
    {
    }
}
