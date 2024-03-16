using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "enum");

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Locale = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TournamentPlayerStatus",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPlayerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Genre_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "dbo",
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "binary(64)", fixedLength: true, maxLength: 64, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "binary(128)", fixedLength: true, maxLength: 128, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "enum",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamSize = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Infos = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: false),
                    Rules = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: false),
                    Settings = table.Column<string>(type: "nvarchar(max)", maxLength: -1, nullable: false),
                    MinimumPlayers = table.Column<int>(type: "int", nullable: false),
                    MaximumPlayers = table.Column<int>(type: "int", nullable: false),
                    AnyoneCanJoin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournament_Game_GameId",
                        column: x => x.GameId,
                        principalSchema: "dbo",
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournament_Platform_PlatformId",
                        column: x => x.PlatformId,
                        principalSchema: "enum",
                        principalTable: "Platform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTournament",
                schema: "dbo",
                columns: table => new
                {
                    AdminTournamentsId = table.Column<int>(type: "int", nullable: false),
                    AdminsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTournament", x => new { x.AdminTournamentsId, x.AdminsId });
                    table.ForeignKey(
                        name: "FK_AccountTournament_Account_AdminsId",
                        column: x => x.AdminsId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTournament_Tournament_AdminTournamentsId",
                        column: x => x.AdminTournamentsId,
                        principalSchema: "dbo",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Match",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    NextMatchId = table.Column<int>(type: "int", nullable: true),
                    FirstTeamId = table.Column<int>(type: "int", nullable: true),
                    SecondTeamId = table.Column<int>(type: "int", nullable: true),
                    WinnerId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournament",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prize",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prize_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "dbo",
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prize_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionTournament",
                columns: table => new
                {
                    RegionsId = table.Column<int>(type: "int", nullable: false),
                    TournamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionTournament", x => new { x.RegionsId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_RegionTournament_Region_RegionsId",
                        column: x => x.RegionsId,
                        principalSchema: "enum",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegionTournament_Tournament_TournamentsId",
                        column: x => x.TournamentsId,
                        principalSchema: "dbo",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stream",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stream", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stream_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentPlayer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    GameUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "dbo",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_TournamentPlayerStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "enum",
                        principalTable: "TournamentPlayerStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalSchema: "dbo",
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "enum",
                table: "Platform",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "pc", "Pc" },
                    { 2, "playstation", "Playstation" },
                    { 3, "xbox", "Xbox" }
                });

            migrationBuilder.InsertData(
                schema: "enum",
                table: "Region",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "europe", "Europe" },
                    { 2, "north_america", "NorthAmerica" },
                    { 3, "south_america", "SouthAmerica" },
                    { 4, "asia", "Asia" }
                });

            migrationBuilder.InsertData(
                schema: "enum",
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "enum",
                table: "TournamentPlayerStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Rejected" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                schema: "dbo",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTournament_AdminsId",
                schema: "dbo",
                table: "AccountTournament",
                column: "AdminsId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GenreId",
                schema: "dbo",
                table: "Game",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FirstTeamId",
                schema: "dbo",
                table: "Match",
                column: "FirstTeamId",
                filter: "([FirstTeamId] IS NOT NULL)")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Match_NextMatchId",
                schema: "dbo",
                table: "Match",
                column: "NextMatchId",
                filter: "([NextMatchId] IS NOT NULL)")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Match_SecondTeamId",
                schema: "dbo",
                table: "Match",
                column: "SecondTeamId",
                filter: "([SecondTeamId] IS NOT NULL)")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Match_TournamentId",
                schema: "dbo",
                table: "Match",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_WinnerId",
                schema: "dbo",
                table: "Match",
                column: "WinnerId",
                filter: "([WinnerId] IS NOT NULL)")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Prize_CurrencyId",
                schema: "dbo",
                table: "Prize",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Prize_TournamentId",
                schema: "dbo",
                table: "Prize",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionTournament_TournamentsId",
                table: "RegionTournament",
                column: "TournamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stream_TournamentId",
                schema: "dbo",
                table: "Stream",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_GameId",
                schema: "dbo",
                table: "Tournament",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_PlatformId",
                schema: "dbo",
                table: "Tournament",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_AccountId",
                schema: "dbo",
                table: "TournamentPlayer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_StatusId",
                schema: "dbo",
                table: "TournamentPlayer",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_TeamId",
                schema: "dbo",
                table: "TournamentPlayer",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_TournamentId",
                schema: "dbo",
                table: "TournamentPlayer",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTournament",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Match",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Prize",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RegionTournament");

            migrationBuilder.DropTable(
                name: "Stream",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentPlayer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TournamentPlayerStatus",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "Tournament",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "Game",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Platform",
                schema: "enum");

            migrationBuilder.DropTable(
                name: "Genre",
                schema: "dbo");
        }
    }
}
