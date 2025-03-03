
# Employee and Project Management System

This is a simple .NET Core application designed to manage employees, their departments, and the projects they are assigned to. It uses Entity Framework Core for data management and Dapper for optimized queries and stored procedure execution.

## Features

- **Employee Management**: Store and manage employee data, including name, salary, and performance ratings.
- **Department Management**: Store and manage departments within an organization.
- **Project Management**: Track projects and employees assigned to each project.
- **Bonus Calculation**: Calculate employee bonuses based on performance ratings using a stored procedure.

## Technologies

- **.NET Core**: The backend framework used for the application.
- **Entity Framework Core**: For database interaction and ORM functionality.
- **Dapper**: A micro-ORM for executing raw SQL queries and stored procedures efficiently.
- **SQL Server**: Database management system for storing application data.

## Database Schema

- **Employee Table**:
  - `EmpId` (Primary Key)
  - `EmpName`
  - `Salary`
  - `BonusAmount`
  - `PerformanceRating` (1-5 scale for performance)
  - `DepartmentId` (Foreign Key)

- **Department Table**:
  - `DepId` (Primary Key)
  - `DepName`

- **Project Table**:
  - `ProjectId` (Primary Key)
  - `ProjectName`
  - `StartDate`
  - `ProjectDeadline`

- **EmployeeProject Table**:
  - `EmployeeId` (Foreign Key)
  - `ProjectId` (Foreign Key)

## Setup and Installation

### Prerequisites

- .NET Core SDK
- SQL Server (LocalDB or a remote instance)
- Visual Studio or Visual Studio Code

### Clone the Repository

```bash
git clone https://github.com/yourusername/EmployeeAndProjectManagement.git
cd EmployeeAndProjectManagement
```

### Set up the Database

1. **Configure Connection String**: In `AppDbContext.cs`, update the connection string with your SQL Server instance.

```csharp
optionsBuilder.UseSqlServer("Server=localhost;Database=EmployeeAndProject;Trusted_Connection=True;");
```

2. **Create the Database**: Use the `AppDbContext` to create the database and seed initial data.

3. **Run Migrations**: If using Entity Framework migrations, you can run the following commands to set up the database schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Running the Application

1. **Build the Project**:

```bash
dotnet build
```

2. **Run the Application**:

```bash
dotnet run
```

This will start the application and execute the main logic. If you're using Dapper to query the database or execute stored procedures, the application will output the results to the console.

## Stored Procedure: `CalculateEmployeeBonuses`

The stored procedure calculates the employee's bonus based on their performance rating and salary.

```sql
CREATE PROCEDURE CalculateEmployeeBonuses
AS
BEGIN
    SELECT 
        e.EmpId,
        e.EmpName,
        e.Salary,
        e.BonusAmount,
        CASE 
            WHEN e.PerformanceRating = 5 THEN e.Salary * 0.20
            WHEN e.PerformanceRating = 4 THEN e.Salary * 0.15
            ELSE 0
        END AS CalculatedBonus
    FROM Employee e
    WHERE e.PerformanceRating >= 4;
END
```

### Dapper Example

The `Program.cs` file includes a Dapper query to execute the stored procedure and return employee bonuses. The result will be printed on the console.

```csharp
var employeeBonuses = connection.Query<EmployeeBonusDto>("CalculateEmployeeBonuses", 
    commandType: CommandType.StoredProcedure).ToList();
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

- **Author**: [Turki Aloufi](https://github.com/turki-aloufi)
- **Email**: turkialoufi44@gmail.com

---

Feel free to contribute, report issues, or ask questions!
