using Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private readonly IUserAccessService _service;

        public UserAccessController(IUserAccessService service)
        {
            _service = service;
        }

        [HttpGet("{userId}/permissions")]
        public async Task<IActionResult> GetPermissions(Guid userId)
            => Ok(await _service.GetPermissionsAsync(userId));

        [HttpGet("{userId}/request-types")]
        public async Task<IActionResult> GetAllowedRequestTypes(Guid userId)
            => Ok(await _service.GetAllowedRequestTypesAsync(userId));

        [HttpGet("{userId}/departments")]
        public async Task<IActionResult> GetAllowedDepartments(Guid userId)
            => Ok(await _service.GetAllowedDepartmentsAsync(userId));

        [HttpGet("{userId}/funding-sources")]
        public async Task<IActionResult> GetAllowedFundingSources(Guid userId)
            => Ok(await _service.GetAllowedFundingSourcesAsync(userId));

        [HttpGet("{userId}/budget-requests")]
        public async Task<IActionResult> GetAllowedBudgetRequests(Guid userId)
            => Ok(await _service.GetAllowedBudgetRequestsAsync(userId));

        [HttpGet("{userId}/allocations")]
        public async Task<IActionResult> GetAllowedAllocations(Guid userId)
            => Ok(await _service.GetAllowedAllocationsAsync(userId));

        [HttpGet("{userId}/payments")]
        public async Task<IActionResult> GetAllowedPayments(Guid userId)
            => Ok(await _service.GetAllowedPaymentsAsync(userId));

        [HttpGet("{userId}/request-types/{id}")]
        public async Task<IActionResult> CanAccessRequestType(Guid userId, long id)
            => Ok(new { hasAccess = await _service.CanAccessRequestTypeAsync(userId, id) });

        [HttpGet("{userId}/departments/{id}")]
        public async Task<IActionResult> CanAccessDepartment(Guid userId, long id)
            => Ok(new { hasAccess = await _service.CanAccessDepartmentAsync(userId, id) });

        [HttpGet("{userId}/funding-sources/{id}")]
        public async Task<IActionResult> CanAccessFundingSource(Guid userId, long id)
            => Ok(new { hasAccess = await _service.CanAccessFundingSourceAsync(userId, id) });
    }
}
