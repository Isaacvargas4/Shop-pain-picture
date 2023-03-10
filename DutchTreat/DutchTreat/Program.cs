using DutchTreat.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System;

namespace DutchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //var host = BuildWebHost(args);

            if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);

            }
            else
            {

            host.Run();
            //CreateHostBuilder(args).Build().Run();

            }

        }


        private static void RunSeeding(IHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using ( var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
                seeder.Seed();

            }
        }
        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .ConfigureAppConfiguration(SetupConfiguration)
        //        .UseStartup<Startup>()
        //        .Build();



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder blrd)
        {
            blrd.Sources.Clear();
            blrd.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

        }
        

        //private static void SetupConfiguration(WebHostBuilderContext ctx,
        //    IConfigurationBuilder blrd)
        //{
        //    blrd.Sources.Clear();
        //    blrd.SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("config.json")
        //        .AddEnvironmentVariables();

        //}
    }
}
