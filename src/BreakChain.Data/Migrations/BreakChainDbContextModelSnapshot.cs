﻿// <auto-generated />
using System;
using BreakChain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreakChain.Data.Migrations
{
    [DbContext(typeof(BreakChainDbContext))]
    partial class BreakChainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BreakChain.Data.Entities.Competitor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<long>("Wallet")
                        .HasColumnType("bigint");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Competitors");

                    b.HasData(
                        new
                        {
                            Id = "5af2a8ea-3752-4d3f-9f6c-b54be5401f81",
                            Losses = 0,
                            Name = "Joseph",
                            Timestamp = new DateTime(2020, 3, 10, 20, 22, 32, 163, DateTimeKind.Local).AddTicks(6715),
                            Wallet = 200L,
                            Wins = 0
                        },
                        new
                        {
                            Id = "4108e369-9bdf-453c-b99b-d923641a49c5",
                            Losses = 0,
                            Name = "Chris",
                            Timestamp = new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7479),
                            Wallet = 200L,
                            Wins = 0
                        },
                        new
                        {
                            Id = "f430ef18-dd88-4daa-b8cd-58d46e05fd7f",
                            Losses = 0,
                            Name = "Mark",
                            Timestamp = new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7520),
                            Wallet = 200L,
                            Wins = 0
                        },
                        new
                        {
                            Id = "e8f84a6c-e8b6-47ec-b808-24d41921ec01",
                            Losses = 0,
                            Name = "Phil",
                            Timestamp = new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7526),
                            Wallet = 200L,
                            Wins = 0
                        },
                        new
                        {
                            Id = "bf9ff159-300f-457f-8ae0-1e9cd5f46be9",
                            Losses = 0,
                            Name = "James",
                            Timestamp = new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7530),
                            Wallet = 200L,
                            Wins = 0
                        });
                });

            modelBuilder.Entity("BreakChain.Data.Entities.Match", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("CurrentFoulPot")
                        .HasColumnType("bigint");

                    b.Property<string>("LosingCompetitorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("Stake")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("WinningCompetitorId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LosingCompetitorId");

                    b.HasIndex("WinningCompetitorId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BreakChain.Data.Entities.MatchCompetitor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompetitorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MatchId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompetitorId");

                    b.HasIndex("MatchId");

                    b.ToTable("MatchCompetitors");
                });

            modelBuilder.Entity("BreakChain.Data.Entities.Match", b =>
                {
                    b.HasOne("BreakChain.Data.Entities.Competitor", "LosingCompetitor")
                        .WithMany("MatchLosses")
                        .HasForeignKey("LosingCompetitorId");

                    b.HasOne("BreakChain.Data.Entities.Competitor", "WinningCompetitor")
                        .WithMany("MatchWins")
                        .HasForeignKey("WinningCompetitorId");

                    b.OwnsOne("BreakChain.Data.ValueObjects.MatchCompetitorStats", "LosingCompetitorStats", b1 =>
                        {
                            b1.Property<string>("MatchId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CalledTrickShots")
                                .HasColumnType("int");

                            b1.Property<int>("Fouls")
                                .HasColumnType("int");

                            b1.Property<int>("Trickshot")
                                .HasColumnType("int");

                            b1.HasKey("MatchId");

                            b1.ToTable("Matches");

                            b1.WithOwner()
                                .HasForeignKey("MatchId");
                        });

                    b.OwnsOne("BreakChain.Data.ValueObjects.MatchCompetitorStats", "WinningCompetitorStats", b1 =>
                        {
                            b1.Property<string>("MatchId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("CalledTrickShots")
                                .HasColumnType("int");

                            b1.Property<int>("Fouls")
                                .HasColumnType("int");

                            b1.Property<int>("Trickshot")
                                .HasColumnType("int");

                            b1.HasKey("MatchId");

                            b1.ToTable("Matches");

                            b1.WithOwner()
                                .HasForeignKey("MatchId");
                        });
                });

            modelBuilder.Entity("BreakChain.Data.Entities.MatchCompetitor", b =>
                {
                    b.HasOne("BreakChain.Data.Entities.Competitor", "Competitor")
                        .WithMany("Matches")
                        .HasForeignKey("CompetitorId");

                    b.HasOne("BreakChain.Data.Entities.Match", "Match")
                        .WithMany("Competitors")
                        .HasForeignKey("MatchId");
                });
#pragma warning restore 612, 618
        }
    }
}
