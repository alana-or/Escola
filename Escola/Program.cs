using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Escola.Extensions;

namespace Escola
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHostBuilder = CreateWebHostBuilder(args).Build();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == Environments.Development || environment == "Local")
                await webHostBuilder.AplicarSeed();

            webHostBuilder.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
