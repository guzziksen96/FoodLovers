using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FoodLovers.Api.Filters
{
    public abstract class CustomExceptionFilterAttributeBase : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttributeBase> _logger;

        public CustomExceptionFilterAttributeBase(ILogger<CustomExceptionFilterAttributeBase> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;

            code = MapExceptionToHttpCode(context, code);

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new { message = context.Exception.Message });

            _logger.LogError(context.Exception, context.Exception.Message);
        }

        protected abstract HttpStatusCode MapExceptionToHttpCode(ExceptionContext context, HttpStatusCode code);
    }
}
