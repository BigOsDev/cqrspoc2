using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public interface IRequest<out Response> : MediatR.IRequest<Response> where Response : IResponse
    {
        Guid Id { get; }
    }
}
