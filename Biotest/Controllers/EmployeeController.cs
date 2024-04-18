using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            IEnumerable<Employee> employees = await employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee? employee = await employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
            [Required][MaxLength(30)] string Name,
            [Required][MaxLength(30)] string LastName,
            [Required] int GenderID,
            [Required] int EmployeePositionID
        )
        {
            var newEmployee = await employeeService.CreateEmployee(Name, LastName, GenderID, EmployeePositionID);
            return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.EmployeeID }, newEmployee);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(
            [Required] int EmployeeID,
            [MaxLength(30)] string Name,
            [MaxLength(30)] string LastName,
            int GenderID,
            int EmployeePositionID
        )
        {
            var updatedEmployee =
                await employeeService.UpdateEmployee(EmployeeID, Name, LastName, GenderID, EmployeePositionID);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deletedEmployee = await employeeService.DeleteEmployee(id);
            if (deletedEmployee == null) return NotFound();


            return Ok(deletedEmployee);
        }
    }

}
