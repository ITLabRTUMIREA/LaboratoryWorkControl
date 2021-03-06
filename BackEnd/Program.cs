﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Extensions;
using Microsoft.Extensions.Hosting;
using BackEnd.Services.Interfaces;

namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options => options.AllowSynchronousIO = true);//TODO disallow
                    webBuilder.UseStartup<Startup>();
                })
                .UseConfigFile("appsettings.Secret.json", optional: true)
                .UseConfigFile("build.json", true);
    }
}
