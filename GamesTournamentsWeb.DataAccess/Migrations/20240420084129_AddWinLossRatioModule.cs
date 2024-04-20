using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddWinLossRatioModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "enum",
                table: "Module",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "WinLossRatio" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "enum",
                table: "Module",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
