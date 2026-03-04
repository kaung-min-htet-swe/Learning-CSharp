using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialBaseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.CreateTable(
            name: "Department",
            columns: table => new
            {
                DepartmentID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK__Departme__B2079BCDB08FB75D", x => x.DepartmentID);
            });
        
        migrationBuilder.CreateTable(
            name: "Student",
            columns: table => new
            {
                StudentID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                DepartmentID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK__Student__32C52A798F81608D", x => x.StudentID);
                table.ForeignKey(
                    name: "FK_Student_Department",
                    column: x => x.DepartmentID,
                    principalTable: "Department",
                    principalColumn: "DepartmentID");
            });
        
        migrationBuilder.CreateIndex(
            name: "IX_Student_DepartmentID",
            table: "Student",
            column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
