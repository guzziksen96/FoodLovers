using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FoodLovers.Api.Configuration.Startup
{
    public static class SwaggerConfig
    {
        public static IServiceCollection RegisterSwaggerDependencies(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Food Lovers", Version = "v1" });
            });

            return services;
        }
    }
}
