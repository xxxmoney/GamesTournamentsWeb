using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TypoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Sport");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Genre",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "sport");
        }
    }
}
