using CQRS.Definitions;
using CQRS.Interfaces;
using Demo.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace POC.Infrastructure
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next; 
        private readonly ILogger logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            Result result;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = new ObjectResult<IDictionary<string, string[]>>(validationException.Failures, false, "Validation error");
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    result = Result.Failed("Not found");
                    break;
                default:
                    result = Result.Failed("Unexpected error");
                    logger.LogError(-1,exception, "Unexpected error");
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;


            return context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }

    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
