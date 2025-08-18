using Application.Contracts;
using Application.Dto.FundingSource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundingSourceController : ControllerBase
    {

        private readonly IFundingSourceService _service;

        public FundingSourceController (IFundingSourceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllFundingSourceDto>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdFundingSourceDto>> GetById(long id)
        {
            var result = await _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddFundingSourceDto dto)
        {
            await _service.AddAsyinc(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateFundingSourceDto dto)
        {
            var exating = await _service.GetById(id);
            if (exating == null)
                return NotFound();
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        
    }
}
