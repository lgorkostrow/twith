using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Twith.Domain.Common.Exceptions;

namespace Twith.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not DomainException)
            {
                return;
            }

            context.Result = new JsonResult(new {Error = new {context.Exception.Message}})
            {
                StatusCode = 400,
            };
            context.ExceptionHandled = true;
        }
    }
}