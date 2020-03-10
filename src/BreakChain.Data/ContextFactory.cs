using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BreakChain.Data
{
    public sealed class ContextFactory : IDesignTimeDbContextFactory<BreakChainDbContext>
    {
        // Used for design time migrations / seeding
        public BreakChainDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BreakChainDbContext>();

            builder.UseSqlServer("Data Source=DESKTOP-JC;Initial Catalog=BreakChain;Integrated Security=True");
            builder.EnableSensitiveDataLogging();

            return new BreakChainDbContext(builder.Options);
        }
    }
}
