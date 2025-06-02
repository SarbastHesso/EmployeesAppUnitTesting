using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeesApp.Infrastructure.Persistance
{
    // Denna konstruktor krävs för att konfigurationen i Program.cs ska fungera
    public class ApplicationContext(DbContextOptions<ApplicationContext> options)
    : DbContext(options)
    {
        // Exponerar våra entiteter via properties av typen DbSet<T>
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .Property(o => o.Salary)
                .HasColumnType(SqlDbType.Money.ToString());
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 562,
                    Name = "Anders Hejlsberg",
                    Email = "Anders.Hejlsberg@outlook.com",
                    Salary = 30000
                },
                new Employee()
                {
                    Id = 62,
                    Name = "Kathleen Dollard",
                    Email = "k.d@outlook.com",
                    Salary = 32000
                },
                new Employee()
                {
                    Id = 15662,
                    Name = "Mads Torgersen",
                    Email = "Admin.Torgersen@outlook.com",
                    Salary = 40000
                },
                new Employee()
                {
                    Id = 52,
                    Name = "Scott Hanselman",
                    Email = "s.h@outlook.com",
                    Salary = 50000
                },
                new Employee()
                {
                    Id = 563,
                    Name = "Jon Skeet",
                    Email = "j.s@outlook.com",
                    Salary = 600500
                }
            );

        }


       
    }
}
