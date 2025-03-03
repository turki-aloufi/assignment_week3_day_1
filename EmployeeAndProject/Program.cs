using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EmployeeAndProject.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=EmployeeAndProject;Trusted_Connection=True;";
        Console.WriteLine("Hello there");

        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Database Connected!");
        }



        var sixMonthsAgo = DateTime.Now.AddMonths(-16);

        var employees = new AppDbContext().Employee
            .Where(e => e.EmployeeProjects
                .Count(ep => ep.Project.StartDate >= sixMonthsAgo) > 3)
            .ToList();

        foreach (var employee in employees)
        {
            Console.WriteLine($"Employee: {employee.EmpName}, Projects Count: {employee.EmployeeProjects.Count}");
        }


        using (var connection = new SqlConnection(connectionString))
        {

            var query = @"
        SELECT 
            e.EmpName AS EmployeeName, 
            p.ProjectName, 
            p.ProjectDeadline
        FROM 
            Employee e
        JOIN 
            EmployeeProject ep ON e.EmpId = ep.EmployeeId
        JOIN 
            Project p ON ep.ProjectId = p.ProjectId";

            var result = connection.Query<EmployeeProjectDto>(query).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"Employee: {item.EmployeeName}, Project: {item.ProjectName}, Deadline: {item.ProjectDeadline}");
            }


        }

}
}
public class EmployeeProjectDto
{
    public string EmployeeName { get; set; }
    public string ProjectName { get; set; }
    public DateTime ProjectDeadline { get; set; }
}
