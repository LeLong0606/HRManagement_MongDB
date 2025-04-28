using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/employees")]
    [ApiController]
    public class HREmployeeController : ControllerBase
    {
        private readonly HREmployeeService _employeeService;
        public HREmployeeController(HREmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }
        [HttpGet("{id:length(24)}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> GetById(string id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            await _employeeService.CreateAsync(employee);
            return CreatedAtRoute("GetEmployee", new { id = employee.Id }, employee);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Employee employee)
        {
            var existingEmployee = await _employeeService.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            employee.Id = existingEmployee.Id; // Ensure the ID is set
            await _employeeService.UpdateAsync(id, employee);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingEmployee = await _employeeService.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            await _employeeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
