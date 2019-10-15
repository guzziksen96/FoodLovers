using System.Reflection;
using FoodLovers.Application.Infrastructure;
using FoodLovers.Application.Scraper.Commands;
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
            services.AddMediatR(typeof(ScrapRecipesCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
