using Application.Dto.Allocation;
using Application.Dto.BudgetRequest;
using Application.Dto.FundingSource;
using Application.Dto.Payment;
using Application.Dto.RequestingDepartmen;
using Application.Dto.RequestType;
using Application.Dto.UserAccess;
using Domain.UserPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserAccessService
    {
        Task<UserPermissions> GetPermissionsAsync(Guid userId);

        // 10 تا GET endpoint جدید برای دسترسی‌های کاربر
        Task<IEnumerable<UserEntityAccessDto>> GetUserRequestTypeAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserRequestingDepartmentAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserFundingSourceAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserBudgetRequestAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserAllocationAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserPaymentAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserPaymentMethodAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserAccessGroupAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserActionBudgetRequestAccessAsync(Guid userId);
        Task<IEnumerable<UserEntityAccessDto>> GetUserAllocationActionBudgetRequestAccessAsync(Guid userId);

        // متدهای قبلی (برای سازگاری)
        Task<IEnumerable<GetAllRequestTypeDto>> GetAllowedRequestTypesAsync(Guid userId);
        Task<IEnumerable<GetAllRequestingDepartmenDto>> GetAllowedDepartmentsAsync(Guid userId);
        Task<IEnumerable<GetAllFundingSourceDto>> GetAllowedFundingSourcesAsync(Guid userId);
        Task<IEnumerable<GetAllBudgetRequestDto>> GetAllowedBudgetRequestsAsync(Guid userId);
        Task<IEnumerable<GetAllocationDto>> GetAllowedAllocationsAsync(Guid userId);
        Task<IEnumerable<GetAllPaymentDto>> GetAllowedPaymentsAsync(Guid userId);
        Task<bool> CanAccessRequestTypeAsync(Guid userId, long id);
        Task<bool> CanAccessDepartmentAsync(Guid userId, long id);
        Task<bool> CanAccessFundingSourceAsync(Guid userId, long id);
    }
}