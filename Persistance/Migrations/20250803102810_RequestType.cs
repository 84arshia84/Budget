using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RequestType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "RequestTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FundingSources",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RequestTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FundingSources",
                newName: "id");
        }
    }
}
