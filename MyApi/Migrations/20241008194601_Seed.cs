using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "CompetitorType", "Country", "EventId", "OrganizationId", "ParticipantId", "PrintInitialName", "PrintName", "Rank", "ScoreboardName", "Seed", "TvInitialName", "TvName" },
                values: new object[] { "SWE-1001", "A", "SWE", null, null, null, null, "Kenny Westermark (PRINT)", null, "K. Westgrund (SB)", null, null, "K. WEST (TV)" });

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "HomeCompetitorId",
                value: "SWE-1001");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "SWE-1001");

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "HomeCompetitorId",
                value: null);
        }
    }
}
