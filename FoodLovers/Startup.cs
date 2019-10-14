using FoodLovers.Api.Configuration;
using FoodLovers.Api.Configuration.Startup;
using FoodLovers.Infrastructure.Elastic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodLovers.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterIoDependecies(Configuration);
            services.RegisterAutoMapperDependecies();
            services.RegisterContextDependencies(Configuration);
            services.AddApiSettings();
            services.AddMediatRSettings();
            services.RegisterSwaggerDependencies();
            services.AddOptions();
            services.Configure<ElasticConnectionSettings>(Configuration.GetSection("ElasticConnectionSettings"));
            services.AddSingleton(typeof(ElasticClientProvider));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var swaggerUrl = "/swagger/v1/swagger.json";
                if (!env.IsDevelopment())
                    swaggerUrl = "/foodloversapi" + swaggerUrl;

                c.SwaggerEndpoint(swaggerUrl, "FoodLovers Api v1");
            });

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
