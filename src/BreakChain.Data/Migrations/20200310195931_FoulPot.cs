using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreakChain.Data.Migrations
{
    public partial class FoulPot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CurrentFoulPot",
                table: "Matches",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CurrentFoulPot",
                table: "Matches");
        }
    }
}
