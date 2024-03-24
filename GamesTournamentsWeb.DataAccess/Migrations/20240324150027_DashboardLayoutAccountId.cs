using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DashboardLayoutAccountId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                schema: "dbo",
                table: "Layout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Layout_AccountId",
                schema: "dbo",
                table: "Layout",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Layout_Account_AccountId",
                schema: "dbo",
                table: "Layout",
                column: "AccountId",
                principalSchema: "dbo",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Layout_Account_AccountId",
                schema: "dbo",
                table: "Layout");

            migrationBuilder.DropIndex(
                name: "IX_Layout_AccountId",
                schema: "dbo",
                table: "Layout");

            migrationBuilder.DropColumn(
                name: "AccountId",
                schema: "dbo",
                table: "Layout");
        }
    }
}
