using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundingSources",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingSources", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RequestingDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestingDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BudgetRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestingDepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    RequestTypeId = table.Column<long>(type: "bigint", nullable: false),
                    FundingSourceId = table.Column<long>(type: "bigint", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    budgetEstimationRanges = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BudgetRequests_FundingSources_FundingSourceId",
                        column: x => x.FundingSourceId,
                        principalTable: "FundingSources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetRequests_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetRequests_RequestingDepartments_RequestingDepartmentId",
                        column: x => x.RequestingDepartmentId,
                        principalTable: "RequestingDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetRequests_FundingSourceId",
                table: "BudgetRequests",
                column: "FundingSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetRequests_RequestingDepartmentId",
                table: "BudgetRequests",
                column: "RequestingDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetRequests_RequestTypeId",
                table: "BudgetRequests",
                column: "RequestTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetRequests");

            migrationBuilder.DropTable(
                name: "FundingSources");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "RequestingDepartments");
        }
    }
}
