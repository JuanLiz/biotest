using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionController(IEmployeePositionService employeePositionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEmployeePositions()
        {
            IEnumerable<EmployeePosition> employeePositions = await employeePositionService.GetEmployeePositions();
            return Ok(employeePositions);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeePosition(int id)
        {
            EmployeePosition? employeePosition = await employeePositionService.GetEmployeePosition(id);
            if (employeePosition == null) return NotFound();
            return Ok(employeePosition);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeePosition(
            [Required][MaxLength(50)] string Name
        )
        {
            var employeePosition = await employeePositionService.CreateEmployeePosition(Name);
            return CreatedAtAction(nameof(GetEmployeePosition), new { id = employeePosition.EmployeePositionID }, employeePosition);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployeePosition(
            [Required] int EmployeePositionID,
            [MaxLength(50)] string Name
        )
        {
            var updatedEmployeePosition = await employeePositionService.UpdateEmployeePosition(EmployeePositionID, Name);
            return Ok(updatedEmployeePosition);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployeePosition(int id)
        {
            var deletedEmployeePosition = await employeePositionService.DeleteEmployeePosition(id);
            if (deletedEmployeePosition == null) return NotFound();
            return Ok(deletedEmployeePosition);
        }
    }
}
