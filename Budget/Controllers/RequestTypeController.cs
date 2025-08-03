using Application.Contracts;
using Application.Dto.RequestType;
using Domain.RequestType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypeController : ControllerBase
    {
        private readonly IRequestTypeService _Service;

        public RequestTypeController(IRequestTypeService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllRequestTypeDto>>> GetAll()
        {
            var result = await _Service.GetAllAsync();
            return Ok(result); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdRequestTypeDto>> GetById(long id)
        {
            var result = await _Service.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRequestTypeDto dto)
        {
            await _Service.AddAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateRequestTypeDto dto)
        {
            var result = await _Service.GetByIdAsync(id);
            {
                if (result == null)
                    return NotFound();
                await _Service.UpdateAsync(id, dto);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _Service.DeleteAsync(id);
            return Ok();

        }

    }
}
