using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Queries
{
    public interface IQuery<out Response> : IRequest<Response> where Response : IResponse
    {
        Guid Id { get; }
    }
}
