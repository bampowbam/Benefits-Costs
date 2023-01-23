using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paylocity.Models;

namespace Paylocity.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        [HttpGet]
        [Route("/employee/{id}")]
        [Produces("application/json")]
        public ActionResult GetEmployeeBenefits(int id)
        {
            Employee employee = new Employee();
            return Ok(employee);
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
