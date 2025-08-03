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
            return Ok(result); ;
        }
    }
}
