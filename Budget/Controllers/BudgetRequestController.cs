using Application.Contracts;
using Application.Dto.BudgetRequest;
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
        public async Task <IActionResult>Add([FromBody]AddBudgetRequestDto dto)
        { 
            await _Service.AddAsyinc(dto);
            return Ok(dto);
        }


    }
}
