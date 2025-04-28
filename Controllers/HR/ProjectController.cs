using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;
        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }
        [HttpGet("{id:length(24)}", Name = "GetProject")]
        public async Task<ActionResult<Project>> GetById(string id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
    }
}
