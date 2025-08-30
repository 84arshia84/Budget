using Application.Contracts;
using Application.Dto.BudgetRequest;
using Application.Dto.FundingSource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetRequestController : ControllerBase
    {
        private readonly IBudgetRequestService _Service;

        public BudgetRequestController(IBudgetRequestService Service)
        {
            _Service = Service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddBudgetRequestDto dto)
        {
            await _Service.AddAsyinc(dto);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdBudgetRequestDto>> GetByIdAsync(long id)
        {
            var result = await _Service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<GetAllBudgetRequestDto>> GetAllAsync()
        {
            var result = await _Service.GetAllAsync();
            return (Ok(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _Service.DeleteAsyinc(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateBudgetRequestDto dto)
        {
            var exating = await _Service.GetByIdAsync(id);
            if (exating == null)
                return NotFound();
            await _Service.UpdateAsyinc(id, dto);
            return NoContent();
        }

        [HttpGet("with-total")]
        public async Task<IActionResult> GetAllWithTotal()
        {
            var result = await _Service.GetAllTotalActionBudgetAsync();
            return Ok(result);
        }



    }
}
