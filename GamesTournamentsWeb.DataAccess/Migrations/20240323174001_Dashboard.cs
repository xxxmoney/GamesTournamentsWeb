using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesTournamentsWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Dashboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Layout",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "enum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    LayoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LayoutItem_Layout_LayoutId",
                        column: x => x.LayoutId,
                        principalSchema: "dbo",
                        principalTable: "Layout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LayoutItem_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "enum",
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "enum",
                table: "Module",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "TournamentHistory" });

            migrationBuilder.CreateIndex(
                name: "IX_LayoutItem_LayoutId",
                schema: "dbo",
                table: "LayoutItem",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_LayoutItem_ModuleId",
                schema: "dbo",
                table: "LayoutItem",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LayoutItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Layout",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "enum");
        }
    }
}
