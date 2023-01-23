using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Models;

namespace Paylocity.Controllers
{
    //[Authorize]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        [HttpDelete]
        [Route("/employee/{id}")]
        [Produces("application/json")]
        public ActionResult DeleteEmployee(int id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("/employee/{id}")]
        [Authorize]
        [Produces("application/json")]
        public ActionResult GetEmployee(int id)
        {
            return Ok(new Employee());
        }


        [HttpGet]
        [Route("/employee")]
        [Produces("application/json")]
        public ActionResult GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            return Ok(employees);
        }

        [HttpPost]
        [Route("/employee")]
        [Produces("application/json")]
        public ActionResult AddEmployee(Employee newEmployee)
        {
            return Ok(new Employee());
        }

        [HttpPut]
        [Route("/employee/{id}")]
        [Produces("application/json")]
        public ActionResult UpdateEmployee([FromRoute] int id, [FromBody] Employee details)
        {
            return Ok();
        }
    }

}
