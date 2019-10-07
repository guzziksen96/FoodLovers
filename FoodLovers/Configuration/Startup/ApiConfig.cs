
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using System.Linq;
using FoodLovers.Api.Filters;
using FoodLovers.Common.Converters;

namespace FoodLovers.Api.Configuration.Startup
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiSettings(this IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));

                    var jsonFormatter = options.InputFormatters.OfType<JsonInputFormatter>().First();
                    jsonFormatter.SupportedMediaTypes.Add("multipart/form-data");
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Insert(0, new TrimmingStringConverter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<tCommandValidator>())
                //todo
                .AddJsonOptions(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            return services;
        }
    }
}
