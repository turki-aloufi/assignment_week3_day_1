using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAndProject.Models
{
    public class AppDbContext : DbContext
    {
        // ✅ Add constructors
        public AppDbContext() { }  // Default constructor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // ✅ Change to DbSet for proper EF Core mapping
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TURKI\\SQLEXPRESS;Database=EmployeeAndProject;Integrated Security=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasKey(e => e.EmpId);
                e.HasOne(d => d.Department)
                 .WithMany(dep => dep.employees)
                 .HasForeignKey(e => e.DepartmentId);
            });

            modelBuilder.Entity<EmployeeProject>(ep =>
            {
                ep.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

                ep.HasOne(ep => ep.Employee)
                  .WithMany(e => e.EmployeeProjects)
                  .HasForeignKey(ep => ep.EmployeeId);

                ep.HasOne(ep => ep.Project)
                  .WithMany(p => p.EmployeeProjects)
                  .HasForeignKey(ep => ep.ProjectId);
            });

            modelBuilder.Entity<Project>().HasKey(p => p.ProjectId);
            modelBuilder.Entity<Department>().HasKey(d => d.DepId);

            // **Seeding Data**
            modelBuilder.Entity<Department>().HasData(
                new Department { DepId = 1, DepName = "IT" },
                new Department { DepId = 2, DepName = "HR" }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmpId = 1, EmpName = "Alice", DepartmentId = 1 },
                new Employee { EmpId = 2, EmpName = "Bob", DepartmentId = 1 },
                new Employee { EmpId = 3, EmpName = "Charlie", DepartmentId = 2 }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, ProjectName = "AI Development" },
                new Project { ProjectId = 2, ProjectName = "HR Management System" }
            );

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject { EmployeeId = 1, ProjectId = 1 }, // Alice -> AI Development
                new EmployeeProject { EmployeeId = 2, ProjectId = 1 }, // Bob -> AI Development
                new EmployeeProject { EmployeeId = 3, ProjectId = 2 }  // Charlie -> HR Management System
            );
        }
    }
}
