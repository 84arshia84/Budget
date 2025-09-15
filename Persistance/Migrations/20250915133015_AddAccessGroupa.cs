using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessGroupa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentAccessgroupSystemParts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemParts = table.Column<int>(type: "int", nullable: false),
                    AccessGroupEnum = table.Column<int>(type: "int", nullable: false),
                    AccessGroupid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentAccessgroupSystemParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentAccessgroupSystemParts_AccessGroups_AccessGroupid",
                        column: x => x.AccessGroupid,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentAccessgroupSystemParts_AccessGroupid",
                table: "DepartmentAccessgroupSystemParts",
                column: "AccessGroupid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentAccessgroupSystemParts");
        }
    }
}
