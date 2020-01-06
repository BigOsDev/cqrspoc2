using CQRS.Queries;
using Demo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.GridItem.Queries
{
    public class GetGridItemsQueryHandler : IQueryHandler<GetGridItemsQuery, GetGridItemsQueryResult>
    {
        private readonly DemoContext context;

        public GetGridItemsQueryHandler(DemoContext context)
        {
            this.context = context;
        }
        public async Task<GetGridItemsQueryResult> Handle(GetGridItemsQuery request, CancellationToken cancellationToken)
        {
            var data = await context.Items.Select(x => new GridItem()
            {
                Id = x.Id,
                Added = x.Added,
                Another1 = x.Another1,
                Another2 = x.Another2,
                Another3 = x.Another3,
                Another4 = x.Another4,
                Description = x.Description,

                Price = x.Price,
                Rate = x.Rate,
                RestaurantId = x.RestaurantId,
                RestaurantName = x.RestaurantName,
                Title = x.Title,
                Votes = x.Votes,
            }).AsNoTracking().ToListAsync();
            return await Task.FromResult(new GetGridItemsQueryResult(data));
        }
    }
}
