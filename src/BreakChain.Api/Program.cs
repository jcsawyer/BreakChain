using System.Threading.Tasks;
using BreakChain.Api.Extensions;
using Microsoft.Extensions.Hosting;

namespace BreakChain.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await Host.CreateDefaultBuilder().Run<Startup>();
    }
}
