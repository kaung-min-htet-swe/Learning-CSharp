using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAt_Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Student",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                table: "Department",
                newName: "DeletedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Student",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Department",
                newName: "DeleteAt");
        }
    }
}
