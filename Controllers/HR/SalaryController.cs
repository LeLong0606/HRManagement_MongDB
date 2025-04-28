using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/salaries")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly SalaryService _salaryService;
        public SalaryController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }
        [HttpPost]
        public async Task<ActionResult<Salary>> Create(Salary salary)
        {
            await _salaryService.CreateAsync(salary);
            return CreatedAtRoute("GetSalary", new { id = salary.Id }, salary);
        }
        [HttpGet("{id:length(24)}", Name = "GetSalary")]
        public async Task<ActionResult<Salary>> GetById(string id)
        {
            var salary = await _salaryService.GetByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return Ok(salary);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Salary salary)
        {
            var existingSalary = await _salaryService.GetByIdAsync(id);
            if (existingSalary == null)
            {
                return NotFound();
            }
            salary.Id = existingSalary.Id; // Ensure the ID is set
            await _salaryService.UpdateAsync(id, salary);
            return NoContent();
        }
    }
}
