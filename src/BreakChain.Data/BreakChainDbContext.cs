using BreakChain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BreakChain.Data
{
    public class BreakChainDbContext : DbContext
    {
        public DbSet<Competitor> Comptetitors { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchCompetitor> MatchCompetitors { get; set; }

        public BreakChainDbContext() { }
        public BreakChainDbContext(DbContextOptions<BreakChainDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Competitor>().HasMany("Matches").WithOne("Competitor").HasForeignKey("CompetitorId");

            builder.Entity<Match>().HasMany("Competitors").WithOne("Match").HasForeignKey("MatchId");
            builder.Entity<Match>().HasOne("WinningCompetitor").WithMany("MatchWins").HasForeignKey("WinningCompetitorId");
            builder.Entity<Match>().HasOne("LosingCompetitor").WithMany("MatchLosses").HasForeignKey("LosingCompetitorId");

            builder.Entity<MatchCompetitor>().HasOne("Match").WithMany("Competitors").HasForeignKey("MatchId");
            builder.Entity<MatchCompetitor>().HasOne("Competitor").WithMany("Matches").HasForeignKey("CompetitorId");

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Competitor>(x =>
            {
                x.HasData(
                    new Competitor() { Name = "Joseph" },
                    new Competitor() { Name = "Chris" },
                    new Competitor() { Name = "Mark" },
                    new Competitor() { Name = "Phil" },
                    new Competitor() { Name = "James" });
            });
        }
    }
}
