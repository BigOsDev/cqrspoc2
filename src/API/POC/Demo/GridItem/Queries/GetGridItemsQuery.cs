using CQRS.Definitions;
using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.GridItem.Queries
{
   public  class GetGridItemsQuery : IQuery<GetGridItemsQueryResult>
    {
        public Guid Id { get; }
    }
}
