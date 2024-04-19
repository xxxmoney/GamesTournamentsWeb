using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TournamentPlayerExpectedWinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpectedWinnerId",
                schema: "dbo",
                table: "TournamentPlayer",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedWinnerId",
                schema: "dbo",
                table: "TournamentPlayer");
        }
    }
}
