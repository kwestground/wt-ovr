using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class Seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Category", "Discipline", "Division", "Gender", "Name", "Role", "SportClass", "WeightCategory" },
                values: new object[] { "E1", null, "Taekwondo Kyorugi", "Seniors", 1, "Male -80 kg", 0, null, "M -80 kg" });

            migrationBuilder.InsertData(
                table: "Timing",
                columns: new[] { "Id", "Injury", "Rest", "Round" },
                values: new object[] { 1, "1:00", "1:00", "2:00" });

            migrationBuilder.InsertData(
                table: "MatchConfigurations",
                columns: new[] { "Id", "GoldenPointId", "MaxDifference", "MaxPenalties", "Rounds", "Rules", "ThresholdsId", "TimingId", "VideoReplayQuotaId" },
                values: new object[] { "M1", null, 12, null, 3, 1, null, 1, null });

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "MatchConfigurationId",
                value: "M1");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: "E1");

            migrationBuilder.DeleteData(
                table: "MatchConfigurations",
                keyColumn: "Id",
                keyValue: "M1");

            migrationBuilder.DeleteData(
                table: "Timing",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Matchs",
                keyColumn: "Id",
                keyValue: "1",
                column: "MatchConfigurationId",
                value: null);
        }
    }
}
