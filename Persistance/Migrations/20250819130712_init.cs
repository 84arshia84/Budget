using System;
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingSources", x => x.Id);
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
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetRequests_RequestTypes_RequestTypeId",
                        column: x => x.RequestTypeId,
                        principalTable: "RequestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetRequests_RequestingDepartments_RequestingDepartmentId",
                        column: x => x.RequestingDepartmentId,
                        principalTable: "RequestingDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Allocations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BudgetRequestId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allocations_BudgetRequests_BudgetRequestId",
                        column: x => x.BudgetRequestId,
                        principalTable: "BudgetRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllocationActionBudgetRequests",
                columns: table => new
                {
                    AllocationId = table.Column<long>(type: "bigint", nullable: false),
                    ActionBudgetRequestEntityId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    AllocatedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationActionBudgetRequests", x => new { x.AllocationId, x.ActionBudgetRequestEntityId });
                    table.ForeignKey(
                        name: "FK_AllocationActionBudgetRequests_ActionBudgetRequestEntitys_ActionBudgetRequestEntityId",
                        column: x => x.ActionBudgetRequestEntityId,
                        principalTable: "ActionBudgetRequestEntitys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllocationActionBudgetRequests_Allocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "Allocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionBudgetRequestEntitys_BudgetRequestId",
                table: "ActionBudgetRequestEntitys",
                column: "BudgetRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocationActionBudgetRequests_ActionBudgetRequestEntityId",
                table: "AllocationActionBudgetRequests",
                column: "ActionBudgetRequestEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Allocations_BudgetRequestId",
                table: "Allocations",
                column: "BudgetRequestId");

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
                name: "AllocationActionBudgetRequests");

            migrationBuilder.DropTable(
                name: "ActionBudgetRequestEntitys");

            migrationBuilder.DropTable(
                name: "Allocations");

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
