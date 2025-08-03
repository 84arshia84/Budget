using Application.Contracts;
using Application.Dto.RequestingDepartmen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestingDepartmentController : ControllerBase
    {
        private readonly IRequestingDepartmenService _service;

        public RequestingDepartmentController(IRequestingDepartmenService service)
        {
            _service=service;
        }




        [HttpGet]
        public async Task<ActionResult<List<GetAllRequestingDepartmenDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateRequestingDepartmenDto dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRequestingDepartmenDto dto)
        {
            await _service.AddAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdRequestingDepartmenDto>> GetById(long id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}
