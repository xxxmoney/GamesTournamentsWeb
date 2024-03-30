using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TournamentMatchRelationCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                schema: "dbo",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                schema: "dbo",
                table: "Match",
                column: "TournamentId",
                principalSchema: "dbo",
                principalTable: "Tournament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                schema: "dbo",
                table: "Match");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Tournament_TournamentId",
                schema: "dbo",
                table: "Match",
                column: "TournamentId",
                principalSchema: "dbo",
                principalTable: "Tournament",
                principalColumn: "Id");
        }
    }
}
