using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Paylocity.Models;

namespace Paylocity.DAL
{
    public class CostOfBenefitsContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public CostOfBenefitsContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        public CostOfBenefitsContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasMany(c => c.Dependents);

            modelBuilder.Entity<Dependent>()
            .HasOne(e => e.Employee);

            modelBuilder.Entity<Dependent>()
            .Property(t => t.EmployeeID).IsRequired();

            
            modelBuilder.Entity<Employee>()
                .HasData(new List<Employee>()
                {
                
                    new() {FirstName = "Charles ", LastName = "Burns"},
                    new() {FirstName = "Waylon", LastName= "Smithers"},
                    new() {FirstName = "Lenny", LastName ="Leonard"},
                    new() {FirstName = "Carl", LastName="Carlson"},
                    new() {FirstName = "Inanimate", LastName="Carbo"},
                    new() {FirstName = "Homer", LastName= "Simpson"}
                });
            Employee seedEmployee = new Employee()
            {
                FirstName = "Johnny",
                LastName = "Walker"
            };
            
            modelBuilder.Entity<Dependent>()
                .HasData(new List<Dependent>()
                {
                    new() {FirstName = "Wyatt ", LastName = "Burns", Type=Dependent.Types.Child, EmployeeID = seedEmployee.ID},
                    new() {FirstName = "Waylon", LastName= "Smithers", Type=Dependent.Types.Spouse, EmployeeID = seedEmployee.ID},
                });
            Console.WriteLine("calculating cost");
            var book = seedEmployee.CalculateBenefitCost();
            seedEmployee.BenefitCost = book.GetValueOrDefault("BenefitCost");
            seedEmployee.Discount = book.GetValueOrDefault("Discount");

            modelBuilder.Entity<Employee>().HasData(seedEmployee);

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
    
}
