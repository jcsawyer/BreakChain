using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace BreakChain.Api.Extensions
{
    public static class HostBuilderExtensions
    {
        public static async Task Run<T>(this IHostBuilder host) where T : class
            => await host.ConfigureAppConfiguration((context, builder) => builder.Configuration(context))
                .ConfigureWebHostDefaults(builder => builder.UseStartup<T>())
                .Build()
                .RunAsync();
    }
}
