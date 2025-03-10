﻿// <auto-generated />
using System;
using EmployeeAndProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeAndProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250303110133_adding-columns")]
    partial class addingcolumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeAndProject.Models.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"));

                    b.Property<string>("DepName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DepId = 1,
                            DepName = "IT"
                        },
                        new
                        {
                            DepId = 2,
                            DepName = "HR"
                        });
                });

            modelBuilder.Entity("EmployeeAndProject.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            EmpId = 1,
                            DepartmentId = 1,
                            EmpName = "Alice"
                        },
                        new
                        {
                            EmpId = 2,
                            DepartmentId = 1,
                            EmpName = "Bob"
                        },
                        new
                        {
                            EmpId = 3,
                            DepartmentId = 2,
                            EmpName = "Charlie"
                        });
                });

            modelBuilder.Entity("EmployeeAndProject.Models.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProject");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            ProjectId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            ProjectId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            ProjectId = 2
                        });
                });

            modelBuilder.Entity("EmployeeAndProject.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<DateTime>("ProjectDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            ProjectDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "AI Development",
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProjectId = 2,
                            ProjectDeadline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProjectName = "HR Management System",
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EmployeeAndProject.Models.Employee", b =>
                {
                    b.HasOne("EmployeeAndProject.Models.Department", "Department")
                        .WithMany("employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeAndProject.Models.EmployeeProject", b =>
                {
                    b.HasOne("EmployeeAndProject.Models.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeAndProject.Models.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("EmployeeAndProject.Models.Department", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("EmployeeAndProject.Models.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");
                });

            modelBuilder.Entity("EmployeeAndProject.Models.Project", b =>
                {
                    b.Navigation("EmployeeProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
