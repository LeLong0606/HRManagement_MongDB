using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/leaverecords")]
    [ApiController]
    public class HRLeaveRecordController : ControllerBase
    {
        private readonly HRLeaveRecordService _leaveRecordService;
        public HRLeaveRecordController(HRLeaveRecordService leaveRecordService)
        {
            _leaveRecordService = leaveRecordService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRecord>> GetById(string id)
        {
            var record = await _leaveRecordService.GetByIdAsync(id);
            if (record == null) return NotFound();
            return record;
        }
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(string id, [FromBody] string comments)
        {
            var success = await _leaveRecordService.ApproveLeaveAsync(id, comments);
            if (!success) return NotFound();
            return Ok(new { message = "Leave approved successfully." });
        }
        [HttpPost("{id}/reject")]
        public async Task<IActionResult> Reject(string id, [FromBody] string comments)
        {
            var success = await _leaveRecordService.RejectLeaveAsync(id, comments);
            if (!success) return NotFound();
            return Ok(new { message = "Leave rejected successfully." });
        }
    }
}
