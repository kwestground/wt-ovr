using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "SWE-1001",
                column: "PrintInitialName",
                value: "KW");

            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "SWE-1002",
                column: "PrintInitialName",
                value: "AB");

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "EventId",
                value: "E1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "SWE-1001",
                column: "PrintInitialName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "SWE-1002",
                column: "PrintInitialName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "EventId",
                value: null);
        }
    }
}
