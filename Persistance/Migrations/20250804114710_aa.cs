using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionBudgetRequestEntitys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetRequestId = table.Column<long>(type: "bigint", nullable: false),
                    BudgetAmountPeriod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionBudgetRequestEntitys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionBudgetRequestEntitys_BudgetRequests_BudgetRequestId",
                        column: x => x.BudgetRequestId,
                        principalTable: "BudgetRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionBudgetRequestEntitys_BudgetRequestId",
                table: "ActionBudgetRequestEntitys",
                column: "BudgetRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionBudgetRequestEntitys");
        }
    }
}
