using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodLovers.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodLovers.Api.Configuration.Startup
{
    public static class DatabaseConfig
    {
        private const string ConnectionStringName = "FoodLoversDatabase";
        public static IServiceCollection RegisterContextDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FoodLoversDbContext>(async (serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString(ConnectionStringName));
            });
                
            return services;
        }

    }
}
