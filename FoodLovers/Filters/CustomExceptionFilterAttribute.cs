using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FoodLovers.Application.Exceptions;
using FoodLovers.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;

namespace FoodLovers.Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : CustomExceptionFilterAttributeBase
    {
        
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            if (context.Exception.Message.Contains("errors"))
            {
                var validationResponseException = ((SwaggerException) context.Exception).Response;
                var validationResponse =
                    JsonConvert.DeserializeObject<ValidationResponseModel>(validationResponseException);

                context.Exception = new Exception(String.Join(", ", validationResponse.Errors));
                return base.OnExceptionAsync(context);
            }

            return base.OnExceptionAsync(context);
        }

        protected override HttpStatusCode MapExceptionToHttpCode(ExceptionContext context, HttpStatusCode code)
        {
            switch (context.Exception)
            {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
                case InvalidOperationException _:
                case ValidationException _:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            return code;
        }

        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttributeBase> logger) : base(logger)
        {
        }
    }
}
