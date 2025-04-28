using HRManagement.Models;
using HRManagement.Services.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.Controllers.HR
{
    [Route("api/hr/contracts")]
    [ApiController]
    public class HRContractController : ControllerBase
    {
        private readonly HRContractService _contractService;
        public HRContractController(HRContractService contractService)
        {
            _contractService = contractService;
        }
        [HttpPost]
        public async Task<ActionResult> Create(Contract contract)
        {
            await _contractService.CreateAsync(contract);
            return CreatedAtAction(nameof(GetById), new { id = contract.Id }, contract);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> GetById(string id)
        {
            var contract = await _contractService.GetByIdAsync(id);
            if (contract == null) return NotFound();
            return contract;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Contract updatedContract)
        {
            var existingContract = await _contractService.GetByIdAsync(id);
            if (existingContract == null) return NotFound();
            await _contractService.UpdateAsync(id, updatedContract);
            return NoContent();
        }
    }
}
