using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Escola.Seed;

namespace Escola.Extensions
{
    public static class WebHostExtensions
    {
        public static async Task<IWebHost> AplicarSeed(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var escolaSeed = services.GetService<EscolaSeed>();
                await escolaSeed.AplicarSeed();
            }
            return host;
        }
    }
}