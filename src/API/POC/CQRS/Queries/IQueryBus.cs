using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Queries
{
    public interface IQueryBus
    {
        Task<Response> Send<Query, Response>(Query query) where Query : IQuery<Response> where Response : IResponse;
    }
}
