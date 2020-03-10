using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakChain.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbContextMigrate<T>(this IServiceCollection services, Action<DbContextOptionsBuilder> options) 
            where T : DbContext
        {
            services.AddDbContextPool<T>(options);
            services.BuildServiceProvider().GetRequiredService<T>().Database.Migrate();
        }
    }
}
