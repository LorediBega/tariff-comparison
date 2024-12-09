using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TariffComparision.API.Models.Exceptions;
using System.Net;

namespace TariffComparision.API.Helpers.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter, IFilterMetadata
    {
        private readonly ILogger<GlobalExceptionFilter> logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, "An error occurred: {Message}", context.Exception.Message);

            var errorResponse = new
            {
                Messages = new List<string>()
                {
                    context.Exception.Message
                }
            };

            if (context.Exception?.GetType() == typeof(ConsumptionValidationException))
            {
                context.Result = new BadRequestObjectResult(errorResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {

                context.Result = new ObjectResult(errorResponse);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.ExceptionHandled = true;
        }
    }
}
