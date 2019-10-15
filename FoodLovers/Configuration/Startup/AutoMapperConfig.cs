using System.Reflection;
using AutoMapper;
using FoodLovers.Application.Infrastructure.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FoodLovers.Api.Configuration.Startup
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection RegisterAutoMapperDependecies(this IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            return services;
        }
    }
}
