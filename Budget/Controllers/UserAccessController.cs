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

        // 6 تا GET endpoint اصلی - فقط مواردی که کاربر دسترسی دارد
        [HttpGet("{userId}/request-types")]
        public async Task<IActionResult> GetUserRequestTypeAccess(Guid userId)
            => Ok(await _service.GetUserRequestTypeAccessAsync(userId));

        [HttpGet("{userId}/requesting-departments")]
        public async Task<IActionResult> GetUserRequestingDepartmentAccess(Guid userId)
            => Ok(await _service.GetUserRequestingDepartmentAccessAsync(userId));

        [HttpGet("{userId}/funding-sources")]
        public async Task<IActionResult> GetUserFundingSourceAccess(Guid userId)
            => Ok(await _service.GetUserFundingSourceAccessAsync(userId));

        [HttpGet("{userId}/budget-requests")]
        public async Task<IActionResult> GetUserBudgetRequestAccess(Guid userId)
            => Ok(await _service.GetUserBudgetRequestAccessAsync(userId));

        [HttpGet("{userId}/allocations")]
        public async Task<IActionResult> GetUserAllocationAccess(Guid userId)
            => Ok(await _service.GetUserAllocationAccessAsync(userId));

        [HttpGet("{userId}/payments")]
        public async Task<IActionResult> GetUserPaymentAccess(Guid userId)
            => Ok(await _service.GetUserPaymentAccessAsync(userId));

        // متدهای کمکی
        [HttpGet("{userId}/permissions")]
        public async Task<IActionResult> GetPermissions(Guid userId)
            => Ok(await _service.GetPermissionsAsync(userId));
    }
}
