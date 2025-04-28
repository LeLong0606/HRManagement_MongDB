using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/employeeAccounts")]
    [ApiController]
    public class EmployeeAccountController : ControllerBase
    {
        private readonly EmployeeAccountService _employeeAccountService;
        public EmployeeAccountController(EmployeeAccountService employeeAccountService)
        {
            _employeeAccountService = employeeAccountService;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployeeAccount>>> GetAll()
        {
            var employeeAccounts = await _employeeAccountService.GetAllAsync();
            return Ok(employeeAccounts);
        }
        [HttpGet("{id:length(24)}", Name = "GetEmployeeAccount")]
        public async Task<ActionResult<EmployeeAccount>> GetById(string id)
        {
            var employeeAccount = await _employeeAccountService.GetByIdAsync(id);
            if (employeeAccount == null)
            {
                return NotFound();
            }
            return Ok(employeeAccount);
        }
        [HttpGet("employee/{employeeId:length(24)}", Name = "GetEmployeeAccountByEmployeeId")]
        public async Task<ActionResult<EmployeeAccount>> GetByEmployeeId(string employeeId)
        {
            var employeeAccount = await _employeeAccountService.GetByEmployeeIdAsync(employeeId);
            if (employeeAccount == null)
            {
                return NotFound();
            }
            return Ok(employeeAccount);
        }
        [HttpPost]
        public async Task<ActionResult<EmployeeAccount>> Create(EmployeeAccount employeeAccount)
        {
            await _employeeAccountService.CreateAsync(employeeAccount);
            return CreatedAtRoute("GetEmployeeAccount", new { id = employeeAccount.Id }, employeeAccount);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, EmployeeAccount employeeAccount)
        {
            var existingEmployeeAccount = await _employeeAccountService.GetByIdAsync(id);
            if (existingEmployeeAccount == null)
            {
                return NotFound();
            }
            employeeAccount.Id = existingEmployeeAccount.Id; // Ensure the ID is set
            await _employeeAccountService.UpdateAsync(id, employeeAccount);
            return NoContent();
        }
        [HttpPut("{id:length(24)}/status")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody] string status)
        {
            var existingEmployeeAccount = await _employeeAccountService.GetByIdAsync(id);
            if (existingEmployeeAccount == null)
            {
                return NotFound();
            }
            await _employeeAccountService.UpdateStatusAsync(id, status);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var existingEmployeeAccount = await _employeeAccountService.GetByIdAsync(id);
            if (existingEmployeeAccount == null)
            {
                return NotFound();
            }
            await _employeeAccountService.DeleteAsync(id);
            return NoContent();
        }
    }
}
