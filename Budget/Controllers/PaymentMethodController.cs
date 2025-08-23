using Application.Contracts;
using Application.Dto.FundingSource;
using Application.Dto.PaymentMethod;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _service;


        public PaymentMethodController(IPaymentMethodService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<GetAllPaymentMethodDto>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdPaymentMethodDto>> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);
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
        public async Task<IActionResult> Add([FromBody] AddPaymentMethodDto dto)
        {
            await _service.AddAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePaymentMethodDto dto)
        {
            var exating = await _service.GetByIdAsync(id);
            if (exating == null)
                return NotFound();
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

    }
}
