using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeAndProject.Migrations
{
    /// <inheritdoc />
    public partial class addingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepId", "DepName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ProjectName" },
                values: new object[,]
                {
                    { 1, "AI Development" },
                    { 2, "HR Management System" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmpId", "DepartmentId", "EmpName" },
                values: new object[,]
                {
                    { 1, 1, "Alice" },
                    { 2, 1, "Bob" },
                    { 3, 2, "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProject",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeProject",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmpId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmpId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmpId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "DepId",
                keyValue: 2);
        }
    }
}
