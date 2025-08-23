using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeOnAllocationDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocationActionBudgetRequests_Allocations_AllocationId",
                table: "AllocationActionBudgetRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocations_BudgetRequests_BudgetRequestId",
                table: "Allocations");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocationActionBudgetRequests_Allocations_AllocationId",
                table: "AllocationActionBudgetRequests",
                column: "AllocationId",
                principalTable: "Allocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Allocations_BudgetRequests_BudgetRequestId",
                table: "Allocations",
                column: "BudgetRequestId",
                principalTable: "BudgetRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllocationActionBudgetRequests_Allocations_AllocationId",
                table: "AllocationActionBudgetRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Allocations_BudgetRequests_BudgetRequestId",
                table: "Allocations");

            migrationBuilder.AddForeignKey(
                name: "FK_AllocationActionBudgetRequests_Allocations_AllocationId",
                table: "AllocationActionBudgetRequests",
                column: "AllocationId",
                principalTable: "Allocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Allocations_BudgetRequests_BudgetRequestId",
                table: "Allocations",
                column: "BudgetRequestId",
                principalTable: "BudgetRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
