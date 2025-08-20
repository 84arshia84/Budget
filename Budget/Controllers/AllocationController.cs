using Application.Contracts;
using Application.Dto.Allocation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationController : ControllerBase
    {
        private readonly IAllocationService _allocationService;

        public AllocationController(IAllocationService allocationService)
        {
            _allocationService = allocationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllocationDto>>> GetAll()
        {
            var allocations = await _allocationService.GetAllAsync();
            return Ok(allocations);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<GetAllocationDto>> GetById(long id)
        {
            var allocation = await _allocationService.GetById(id);
            if (allocation == null) return NotFound();
            return Ok(allocation);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateAllocationDto dto)
        {
            await _allocationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.BudgetRequestId }, dto);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> Update(long id, [FromBody] UpdateAllocationDto dto)
        {
            if (dto.ActionAllocations == null || !dto.ActionAllocations.Any())
                return BadRequest("At least one action allocation is required.");

            try
            {
                await _allocationService.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _allocationService.DeleteAsync(id);
            return NoContent();
        }
    }
}
