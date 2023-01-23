using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Paylocity.DAL;
using Paylocity.Models;

namespace Paylocity.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }
        
        private readonly CostOfBenefitsContext costOfBenefitsContext;

        public EmployeeRepository(CostOfBenefitsContext costOfBenefitsContext)
        {
            this.costOfBenefitsContext = costOfBenefitsContext;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await costOfBenefitsContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployee(Guid employeeId)
        {
            return await costOfBenefitsContext.Employees
                .FirstOrDefaultAsync(e => e.ID == employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await costOfBenefitsContext.Employees.AddAsync(employee);
            await costOfBenefitsContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await costOfBenefitsContext.Employees
                .FirstOrDefaultAsync(e => e.ID == employee.ID);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Dependents = employee.Dependents;
                result.Discount = employee.Discount;
                result.BenefitCost = employee.BenefitCost;
                

                await costOfBenefitsContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteEmployee(Guid employeeId)
        {
            var result = await costOfBenefitsContext.Employees
                .FirstOrDefaultAsync(e => e.ID == employeeId);
            if (result != null)
            {
                costOfBenefitsContext.Employees.Remove(result);
                await costOfBenefitsContext.SaveChangesAsync();
            }
        }
    }
    
}
