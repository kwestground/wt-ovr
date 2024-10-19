using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchConfigurations_Timing_TimingId",
                table: "MatchConfigurations");

            migrationBuilder.AlterColumn<int>(
                name: "TimingId",
                table: "MatchConfigurations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Competitors",
                columns: new[] { "Id", "CompetitorType", "Country", "EventId", "OrganizationId", "ParticipantId", "PrintInitialName", "PrintName", "Rank", "ScoreboardName", "Seed", "TvInitialName", "TvName" },
                values: new object[] { "SWE-1002", "A", "SWE", null, null, null, null, "Andreas Boström (PRINT)", null, "A. Boström (SB)", null, null, "A. BOST (TV)" });

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "AwayCompetitorId",
                value: "SWE-1002");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchConfigurations_Timing_TimingId",
                table: "MatchConfigurations",
                column: "TimingId",
                principalTable: "Timing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchConfigurations_Timing_TimingId",
                table: "MatchConfigurations");

            migrationBuilder.DeleteData(
                table: "Competitors",
                keyColumn: "Id",
                keyValue: "SWE-1002");

            migrationBuilder.AlterColumn<int>(
                name: "TimingId",
                table: "MatchConfigurations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "AwayCompetitorId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchConfigurations_Timing_TimingId",
                table: "MatchConfigurations",
                column: "TimingId",
                principalTable: "Timing",
                principalColumn: "Id");
        }
    }
}
