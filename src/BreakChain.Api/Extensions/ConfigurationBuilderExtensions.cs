using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BreakChain.Api.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static void Configuration(this IConfigurationBuilder builder, HostBuilderContext context)
            => builder
                .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json")
                .AddEnvironmentVariables();
    }
}
