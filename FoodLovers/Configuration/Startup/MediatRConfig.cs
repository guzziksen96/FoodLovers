using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FoodLovers.Application.Infrastructure;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace FoodLovers.Api.Configuration.Startup
{
    public static class MediatRConfig
    {
        public static IServiceCollection AddMediatRSettings(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            // services.AddMediatR(typeof(MyQuery).GetTypeInfo().Assembly);

            return services;
        }
    }
}
