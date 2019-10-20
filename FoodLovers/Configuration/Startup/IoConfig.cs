using FoodLovers.Application.Scraper.Services;
using FoodLovers.Elastic.Recipe.Autocomplete.Services;
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
            services.AddScoped<IAutocompleteService, AutocompleteService>();
            
            return services;
        }
    }
}
