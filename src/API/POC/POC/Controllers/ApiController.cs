using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS;
using CQRS.Commands;
using CQRS.Interfaces;
using CQRS.Queries;
using Demo.GridItem.Commands;
using Demo.GridItem.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace POC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> logger;

        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public ApiController(ILogger<ApiController> logger, IQueryBus queryBus, ICommandBus commandBus)
        {
            this.logger = logger;
            this.queryBus = queryBus;
            this.commandBus = commandBus;
        }

        [HttpGet]
        public async Task<GetGridItemsQueryResult> Get()
        {
            return await queryBus.Send<GetGridItemsQuery, GetGridItemsQueryResult>(new GetGridItemsQuery());
        }

        [HttpPost]
        public async Task<Result> SetValue(GridValueChangeCommand command)
        {
            return await commandBus.Send<GridValueChangeCommand,Result>(command);
        }
    }
}
