using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Paylocity.Models;

namespace Paylocity.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee?> GetEmployee(Guid employeeId);
        Task<List<Employee>> GetEmployees();
        Task<Employee> AddEmployee(Employee employee);
    }
}