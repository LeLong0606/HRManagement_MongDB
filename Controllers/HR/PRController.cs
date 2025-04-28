using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/performance-reviews")]
    [ApiController]
    public class PRController : ControllerBase
    {
        private readonly PRService _prService;
        public PRController(PRService prService)
        {
            _prService = prService;
        }
        [HttpPost]
        public async Task<ActionResult<PerformanceReview>> Create(PerformanceReview performanceReview)
        {
            if (performanceReview == null) {
                return BadRequest("Performance review cannot be null.");
            }
            await _prService.CreateAsync(performanceReview);
            return CreatedAtRoute("GetPerformanceReview", new { id = performanceReview.Id }, performanceReview);
        }
    }
}
