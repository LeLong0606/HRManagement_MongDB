using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }
        [HttpGet("{id:length(24)}", Name = "GetDepartment")]
        public async Task<ActionResult<Department>> GetById(string id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        [HttpPost]
        public async Task<ActionResult<Department>> Create(Department department)
        {
            await _departmentService.CreateAsync(department);
            return CreatedAtRoute("GetDepartment", new { id = department.Id }, department);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Department department)
        {
            var existingDepartment = await _departmentService.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            department.Id = existingDepartment.Id; // Ensure the ID is set
            await _departmentService.UpdateAsync(id, department);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var existingDepartment = await _departmentService.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }
            await _departmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
