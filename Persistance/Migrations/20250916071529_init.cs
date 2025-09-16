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
                name: "AccessGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroups", x => x.Id);
                });

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
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
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
                name: "AccessGroupFundingSources",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessGroupId = table.Column<long>(type: "bigint", nullable: false),
                    FundingSourceId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupFundingSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupFundingSources_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupProperties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTypeView = table.Column<bool>(type: "bit", nullable: false),
                    RequestTypeCreate = table.Column<bool>(type: "bit", nullable: false),
                    RequestTypeEdit = table.Column<bool>(type: "bit", nullable: false),
                    RequestTypeDelete = table.Column<bool>(type: "bit", nullable: false),
                    RequestingDepartmentView = table.Column<bool>(type: "bit", nullable: false),
                    RequestingDepartmentCreate = table.Column<bool>(type: "bit", nullable: false),
                    RequestingDepartmentEdit = table.Column<bool>(type: "bit", nullable: false),
                    RequestingDepartmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    FundingSourceView = table.Column<bool>(type: "bit", nullable: false),
                    FundingSourceCreate = table.Column<bool>(type: "bit", nullable: false),
                    FundingSourceEdit = table.Column<bool>(type: "bit", nullable: false),
                    FundingSourceDelete = table.Column<bool>(type: "bit", nullable: false),
                    AccessGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupProperties_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupRequestingDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessGroupId = table.Column<long>(type: "bigint", nullable: false),
                    RequestingDepartmentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupRequestingDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupRequestingDepartments_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupRequestTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessGroupId = table.Column<long>(type: "bigint", nullable: false),
                    RequestTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupRequestTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupRequestTypes_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessGroupUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessGroupId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessGroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessGroupUsers_AccessGroups_AccessGroupId",
                        column: x => x.AccessGroupId,
                        principalTable: "AccessGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllocationActionBudgetRequests",
                columns: table => new
                {
                    AllocationId = table.Column<long>(type: "bigint", nullable: false),
                    ActionBudgetRequestEntityId = table.Column<long>(type: "bigint", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllocationId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentMethodId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Allocations_AllocationId",
                        column: x => x.AllocationId,
                        principalTable: "Allocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupFundingSources_AccessGroupId",
                table: "AccessGroupFundingSources",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupProperties_AccessGroupId",
                table: "AccessGroupProperties",
                column: "AccessGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupRequestingDepartments_AccessGroupId",
                table: "AccessGroupRequestingDepartments",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupRequestTypes_AccessGroupId",
                table: "AccessGroupRequestTypes",
                column: "AccessGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessGroupUsers_AccessGroupId",
                table: "AccessGroupUsers",
                column: "AccessGroupId");

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

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentAccessgroupSystemParts_AccessGroupid",
                table: "DepartmentAccessgroupSystemParts",
                column: "AccessGroupid");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AllocationId",
                table: "Payments",
                column: "AllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentMethodId",
                table: "Payments",
                column: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessGroupFundingSources");

            migrationBuilder.DropTable(
                name: "AccessGroupProperties");

            migrationBuilder.DropTable(
                name: "AccessGroupRequestingDepartments");

            migrationBuilder.DropTable(
                name: "AccessGroupRequestTypes");

            migrationBuilder.DropTable(
                name: "AccessGroupUsers");

            migrationBuilder.DropTable(
                name: "AllocationActionBudgetRequests");

            migrationBuilder.DropTable(
                name: "DepartmentAccessgroupSystemParts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ActionBudgetRequestEntitys");

            migrationBuilder.DropTable(
                name: "AccessGroups");

            migrationBuilder.DropTable(
                name: "Allocations");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

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
