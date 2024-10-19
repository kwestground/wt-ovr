using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Matchs",
                columns: new[] { "Id", "AwayCompetitorId", "CompetitorId", "EventId", "HomeCompetitorId", "Mat", "MatchConfigurationId", "Number", "PenaltiesId", "Phase", "RefereeAssignmentId", "ResultId", "Round", "RoundTime", "ScheduleId", "ScoreId", "SessionId", "Status" },
                values: new object[] { "1", null, null, null, null, 1, null, "1-1", null, 7, null, null, null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
