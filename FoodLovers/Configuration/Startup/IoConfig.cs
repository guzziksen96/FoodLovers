using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodLovers.Application.Scraper.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodLovers.Api.Configuration
{
    public static class IoConfig
    {
        public static IServiceCollection RegisterIoDependecies(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IScraperService, ScraperService>();
            return services;
        }
    }
}
