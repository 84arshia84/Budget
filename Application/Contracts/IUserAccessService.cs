using Application.Dto.Allocation;
using Application.Dto.BudgetRequest;
using Application.Dto.FundingSource;
using Application.Dto.Payment;
using Application.Dto.RequestingDepartmen;
using Application.Dto.RequestType;
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

        // فیلتر لیست‌ها
        Task<IEnumerable<GetAllRequestTypeDto>> GetAllowedRequestTypesAsync(Guid userId);
        Task<IEnumerable<GetAllRequestingDepartmenDto>> GetAllowedDepartmentsAsync(Guid userId);
        Task<IEnumerable<GetAllFundingSourceDto>> GetAllowedFundingSourcesAsync(Guid userId);

        Task<IEnumerable<GetAllBudgetRequestDto>> GetAllowedBudgetRequestsAsync(Guid userId);
        Task<IEnumerable<GetAllocationDto>> GetAllowedAllocationsAsync(Guid userId);
        Task<IEnumerable<GetAllPaymentDto>> GetAllowedPaymentsAsync(Guid userId);

        // چک کردن تک مورد
        Task<bool> CanAccessRequestTypeAsync(Guid userId, long id);
        Task<bool> CanAccessDepartmentAsync(Guid userId, long id);
        Task<bool> CanAccessFundingSourceAsync(Guid userId, long id);
    }
}