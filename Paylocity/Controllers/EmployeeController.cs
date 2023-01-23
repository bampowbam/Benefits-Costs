using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Models;
using Paylocity.Repositories;

namespace Paylocity.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("/employee")]
        [Produces("application/json")]
        public async Task<ActionResult> GetEmployees()
        {
            List<Employee?> employees = (List<Employee?>)await _employeeRepository.GetEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("/employee/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> GetEmployee(Guid id)
        {
            Employee? employee =  await _employeeRepository.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPut]
        [Route("/employee/{id}")]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee details)
        {
            Employee? employee = await _employeeRepository.UpdateEmployee(details);
            return Ok();
        }
    }

}
