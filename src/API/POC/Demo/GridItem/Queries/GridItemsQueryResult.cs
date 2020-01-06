using CQRS.Definitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.GridItem.Queries
{
    public class GetGridItemsQueryResult : ObjectResult<List<GridItem>>
    {
        public GetGridItemsQueryResult(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public GetGridItemsQueryResult(List<GridItem> result, bool isSuccess = true, string message = null) : base(result, isSuccess, message)
        {
        }
    }
}
