using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffSchedulerApi.Migrations
{
    /// <inheritdoc />
    public partial class initializerAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "roles",
                newName: "Id");
        }
    }
}
