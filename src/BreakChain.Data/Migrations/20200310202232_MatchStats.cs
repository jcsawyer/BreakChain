using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreakChain.Data.Migrations
{
    public partial class MatchStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "037bda36-b070-4087-bee3-19fa786e0dd4");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "05f50b52-fb49-437d-9dea-a1d7b7927f97");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "2b5c7939-f841-4aa4-b739-d9295cd73528");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "4b2869a9-d4b9-45f1-9c0c-f63b7f87ef59");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "ba215c0b-02d5-40e4-b437-410a71d3b6d7");

            migrationBuilder.AddColumn<int>(
                name: "LosingCompetitorStats_CalledTrickShots",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LosingCompetitorStats_Fouls",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LosingCompetitorStats_Trickshot",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinningCompetitorStats_CalledTrickShots",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinningCompetitorStats_Fouls",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WinningCompetitorStats_Trickshot",
                table: "Matches",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "Losses", "Name", "Timestamp", "Wallet", "Wins" },
                values: new object[,]
                {
                    { "5af2a8ea-3752-4d3f-9f6c-b54be5401f81", 0, "Joseph", new DateTime(2020, 3, 10, 20, 22, 32, 163, DateTimeKind.Local).AddTicks(6715), 200L, 0 },
                    { "4108e369-9bdf-453c-b99b-d923641a49c5", 0, "Chris", new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7479), 200L, 0 },
                    { "f430ef18-dd88-4daa-b8cd-58d46e05fd7f", 0, "Mark", new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7520), 200L, 0 },
                    { "e8f84a6c-e8b6-47ec-b808-24d41921ec01", 0, "Phil", new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7526), 200L, 0 },
                    { "bf9ff159-300f-457f-8ae0-1e9cd5f46be9", 0, "James", new DateTime(2020, 3, 10, 20, 22, 32, 165, DateTimeKind.Local).AddTicks(7530), 200L, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "4108e369-9bdf-453c-b99b-d923641a49c5");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "5af2a8ea-3752-4d3f-9f6c-b54be5401f81");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "bf9ff159-300f-457f-8ae0-1e9cd5f46be9");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "e8f84a6c-e8b6-47ec-b808-24d41921ec01");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "f430ef18-dd88-4daa-b8cd-58d46e05fd7f");

            migrationBuilder.DropColumn(
                name: "LosingCompetitorStats_CalledTrickShots",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LosingCompetitorStats_Fouls",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LosingCompetitorStats_Trickshot",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "WinningCompetitorStats_CalledTrickShots",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "WinningCompetitorStats_Fouls",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "WinningCompetitorStats_Trickshot",
                table: "Matches");

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "Losses", "Name", "Timestamp", "Wallet", "Wins" },
                values: new object[,]
                {
                    { "ba215c0b-02d5-40e4-b437-410a71d3b6d7", 0, "Joseph", new DateTime(2020, 3, 10, 19, 59, 31, 429, DateTimeKind.Local).AddTicks(3440), 200L, 0 },
                    { "2b5c7939-f841-4aa4-b739-d9295cd73528", 0, "Chris", new DateTime(2020, 3, 10, 19, 59, 31, 431, DateTimeKind.Local).AddTicks(3287), 200L, 0 },
                    { "05f50b52-fb49-437d-9dea-a1d7b7927f97", 0, "Mark", new DateTime(2020, 3, 10, 19, 59, 31, 431, DateTimeKind.Local).AddTicks(3325), 200L, 0 },
                    { "4b2869a9-d4b9-45f1-9c0c-f63b7f87ef59", 0, "Phil", new DateTime(2020, 3, 10, 19, 59, 31, 431, DateTimeKind.Local).AddTicks(3331), 200L, 0 },
                    { "037bda36-b070-4087-bee3-19fa786e0dd4", 0, "James", new DateTime(2020, 3, 10, 19, 59, 31, 431, DateTimeKind.Local).AddTicks(3335), 200L, 0 }
                });
        }
    }
}
