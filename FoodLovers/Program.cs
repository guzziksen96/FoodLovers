﻿using FoodLovers.Api;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FoodLovers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIIS()
                .UseStartup<Startup>();
    }
}
