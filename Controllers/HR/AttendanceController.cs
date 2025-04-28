using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/attendances")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Attendance>>> GetAll()
        {
            var attendances = await _attendanceService.GetAllAsync();
            return Ok(attendances);
        }
        [HttpGet("{id:length(24)}", Name = "GetAttendance")]
        public async Task<ActionResult<Attendance>> GetById(string id)
        {
            var attendance = await _attendanceService.GetByEmployeeIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }
    }
}
