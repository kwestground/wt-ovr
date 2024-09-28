using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoldenPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoldenPoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchInternalResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeType = table.Column<int>(type: "int", nullable: false),
                    AwayType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchInternalResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ScheduledStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualStart = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchSchedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchScore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Home = table.Column<int>(type: "int", nullable: true),
                    Away = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchScore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thresholds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<int>(type: "int", nullable: true),
                    Head = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thresholds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Injury = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedalWinners",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: true),
                    MedalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedalWinners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedalWinners_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportGivenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportFamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredGivenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredFamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintInitialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvInitialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreboardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainRole = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchConfigurations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rules = table.Column<int>(type: "int", nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: true),
                    TimingId = table.Column<int>(type: "int", nullable: true),
                    ThresholdsId = table.Column<int>(type: "int", nullable: true),
                    VideoReplayQuotaId = table.Column<int>(type: "int", nullable: true),
                    GoldenPointId = table.Column<int>(type: "int", nullable: true),
                    MaxDifference = table.Column<int>(type: "int", nullable: true),
                    MaxPenalties = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchConfigurations_GoldenPoint_GoldenPointId",
                        column: x => x.GoldenPointId,
                        principalTable: "GoldenPoint",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchConfigurations_MatchScore_VideoReplayQuotaId",
                        column: x => x.VideoReplayQuotaId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchConfigurations_Thresholds_ThresholdsId",
                        column: x => x.ThresholdsId,
                        principalTable: "Thresholds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchConfigurations_Timing_TimingId",
                        column: x => x.TimingId,
                        principalTable: "Timing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Competitors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompetitorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintInitialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvInitialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreboardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Seed = table.Column<int>(type: "int", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParticipantId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitors_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competitors_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Competitors_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchRefereeAssignments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefJ1Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefJ2Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefJ3Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefCRId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefRJId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefTAId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRefereeAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRefereeAssignments_Participants_RefCRId",
                        column: x => x.RefCRId,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchRefereeAssignments_Participants_RefJ1Id",
                        column: x => x.RefJ1Id,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchRefereeAssignments_Participants_RefJ2Id",
                        column: x => x.RefJ2Id,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchRefereeAssignments_Participants_RefJ3Id",
                        column: x => x.RefJ3Id,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchRefereeAssignments_Participants_RefRJId",
                        column: x => x.RefRJId,
                        principalTable: "Participants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchRefereeAssignments_Participants_RefTAId",
                        column: x => x.RefTAId,
                        principalTable: "Participants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mat = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phase = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    ResultId = table.Column<int>(type: "int", nullable: true),
                    ScoreId = table.Column<int>(type: "int", nullable: true),
                    PenaltiesId = table.Column<int>(type: "int", nullable: true),
                    Round = table.Column<int>(type: "int", nullable: true),
                    RoundTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeCompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AwayCompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RefereeAssignmentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MatchConfigurationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Competitors_AwayCompetitorId",
                        column: x => x.AwayCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Competitors_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Competitors_HomeCompetitorId",
                        column: x => x.HomeCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_MatchConfigurations_MatchConfigurationId",
                        column: x => x.MatchConfigurationId,
                        principalTable: "MatchConfigurations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_MatchInternalResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "MatchInternalResult",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_MatchRefereeAssignments_RefereeAssignmentId",
                        column: x => x.RefereeAssignmentId,
                        principalTable: "MatchRefereeAssignments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_MatchSchedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "MatchSchedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_MatchScore_PenaltiesId",
                        column: x => x.PenaltiesId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_MatchScore_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matchs_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchActions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Action = table.Column<int>(type: "int", nullable: false),
                    Hitlevel = table.Column<int>(type: "int", nullable: true),
                    Round = table.Column<int>(type: "int", nullable: true),
                    RoundTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    ScoreId = table.Column<int>(type: "int", nullable: true),
                    PenaltiesId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HomeCompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AwayCompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchActions_Competitors_AwayCompetitorId",
                        column: x => x.AwayCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchActions_Competitors_HomeCompetitorId",
                        column: x => x.HomeCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchActions_MatchScore_PenaltiesId",
                        column: x => x.PenaltiesId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchActions_MatchScore_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchActions_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchResults",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    ResultId = table.Column<int>(type: "int", nullable: true),
                    ScoreId = table.Column<int>(type: "int", nullable: true),
                    PenaltiesId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HomeCompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AwayCompetitorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchResults_Competitors_AwayCompetitorId",
                        column: x => x.AwayCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchResults_Competitors_HomeCompetitorId",
                        column: x => x.HomeCompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchResults_MatchInternalResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "MatchInternalResult",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchResults_MatchScore_PenaltiesId",
                        column: x => x.PenaltiesId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchResults_MatchScore_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "MatchScore",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchResults_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_EventId",
                table: "Competitors",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_OrganizationId",
                table: "Competitors",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitors_ParticipantId",
                table: "Competitors",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchActions_AwayCompetitorId",
                table: "MatchActions",
                column: "AwayCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchActions_HomeCompetitorId",
                table: "MatchActions",
                column: "HomeCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchActions_MatchId",
                table: "MatchActions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchActions_PenaltiesId",
                table: "MatchActions",
                column: "PenaltiesId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchActions_ScoreId",
                table: "MatchActions",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchConfigurations_GoldenPointId",
                table: "MatchConfigurations",
                column: "GoldenPointId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchConfigurations_ThresholdsId",
                table: "MatchConfigurations",
                column: "ThresholdsId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchConfigurations_TimingId",
                table: "MatchConfigurations",
                column: "TimingId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchConfigurations_VideoReplayQuotaId",
                table: "MatchConfigurations",
                column: "VideoReplayQuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRefereeAssignments_RefCRId",
                table: "MatchRefereeAssignments",
                column: "RefCRId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRefereeAssignments_RefJ1Id",
                table: "MatchRefereeAssignments",
                column: "RefJ1Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRefereeAssignments_RefJ2Id",
                table: "MatchRefereeAssignments",
                column: "RefJ2Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRefereeAssignments_RefJ3Id",
                table: "MatchRefereeAssignments",
                column: "RefJ3Id");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRefereeAssignments_RefRJId",
                table: "MatchRefereeAssignments",
                column: "RefRJId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRefereeAssignments_RefTAId",
                table: "MatchRefereeAssignments",
                column: "RefTAId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_AwayCompetitorId",
                table: "MatchResults",
                column: "AwayCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_HomeCompetitorId",
                table: "MatchResults",
                column: "HomeCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_MatchId",
                table: "MatchResults",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_PenaltiesId",
                table: "MatchResults",
                column: "PenaltiesId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_ResultId",
                table: "MatchResults",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchResults_ScoreId",
                table: "MatchResults",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_AwayCompetitorId",
                table: "Matchs",
                column: "AwayCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_CompetitorId",
                table: "Matchs",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_EventId",
                table: "Matchs",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_HomeCompetitorId",
                table: "Matchs",
                column: "HomeCompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_MatchConfigurationId",
                table: "Matchs",
                column: "MatchConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_PenaltiesId",
                table: "Matchs",
                column: "PenaltiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_RefereeAssignmentId",
                table: "Matchs",
                column: "RefereeAssignmentId",
                unique: true,
                filter: "[RefereeAssignmentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_ResultId",
                table: "Matchs",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_ScheduleId",
                table: "Matchs",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_ScoreId",
                table: "Matchs",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_SessionId",
                table: "Matchs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedalWinners_EventId",
                table: "MedalWinners",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_OrganizationId",
                table: "Participants",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchActions");

            migrationBuilder.DropTable(
                name: "MatchResults");

            migrationBuilder.DropTable(
                name: "MedalWinners");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Competitors");

            migrationBuilder.DropTable(
                name: "MatchConfigurations");

            migrationBuilder.DropTable(
                name: "MatchInternalResult");

            migrationBuilder.DropTable(
                name: "MatchRefereeAssignments");

            migrationBuilder.DropTable(
                name: "MatchSchedule");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "GoldenPoint");

            migrationBuilder.DropTable(
                name: "MatchScore");

            migrationBuilder.DropTable(
                name: "Thresholds");

            migrationBuilder.DropTable(
                name: "Timing");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
