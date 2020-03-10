using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreakChain.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Wallet = table.Column<long>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Stake = table.Column<long>(nullable: false),
                    WinningCompetitorId = table.Column<string>(nullable: true),
                    LosingCompetitorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Competitors_LosingCompetitorId",
                        column: x => x.LosingCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Competitors_WinningCompetitorId",
                        column: x => x.WinningCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchCompetitors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    CompetitorId = table.Column<string>(nullable: true),
                    MatchId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchCompetitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchCompetitors_Competitors_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchCompetitors_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchCompetitors_CompetitorId",
                table: "MatchCompetitors",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchCompetitors_MatchId",
                table: "MatchCompetitors",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LosingCompetitorId",
                table: "Matches",
                column: "LosingCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinningCompetitorId",
                table: "Matches",
                column: "WinningCompetitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchCompetitors");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Competitors");
        }
    }
}
