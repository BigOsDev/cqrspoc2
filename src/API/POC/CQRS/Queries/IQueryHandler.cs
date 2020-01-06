using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CQRS.Commands;
using MediatR;

namespace CQRS.Queries
{
    public interface IQueryHandler<Query,Result> : IRequestHandler<Query, Result> where Query : IQuery<Result> where Result : IResponse
    {
    }
}
