using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessGroup : Migration
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
                name: "AccessGroups");
        }
    }
}
