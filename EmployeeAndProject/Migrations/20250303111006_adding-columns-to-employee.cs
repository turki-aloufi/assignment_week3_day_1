using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAndProject.Migrations
{
    /// <inheritdoc />
    public partial class addingcolumnstoemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BonusAmount",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmpId",
                keyValue: 1,
                columns: new[] { "BonusAmount", "Salary" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmpId",
                keyValue: 2,
                columns: new[] { "BonusAmount", "Salary" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmpId",
                keyValue: 3,
                columns: new[] { "BonusAmount", "Salary" },
                values: new object[] { 0m, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BonusAmount",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employee");
        }
    }
}
