using Application.Contracts;
using Application.Dto.Allocation;
using Application.Dto.BudgetRequest;
using Application.Dto.FundingSource;
using Application.Dto.Payment;
using Application.Dto.RequestingDepartmen;
using Application.Dto.RequestType;
using Application.Dto.UserAccess;
using Application.Mapper;
using Application.Mapper.Allocation;
using Domain.Allocation;
using Domain.BudgetRequest;
using Domain.FundingSource;
using Domain.Payment;
using Domain.RequestingDepartment;
using Domain.RequestType;
using Domain.UserPermissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAccessService : IUserAccessService
    {
        private readonly IUserAccessRepository _repo;
        private readonly IRequestTypeRepository _requestTypeRepo;
        private readonly IRequestingDepartmentRepository _departmentRepo;
        private readonly IFundingSourceRepository _fundingRepo;
        private readonly IBudgetRequestRepository _budgetRepo;
        private readonly IAllocationRepository _allocationRepo;
        private readonly IPaymentRepository _paymentRepo;

        public UserAccessService(
            IUserAccessRepository repo,
            IRequestTypeRepository requestTypeRepo,
            IRequestingDepartmentRepository departmentRepo,
            IFundingSourceRepository fundingRepo,
            IBudgetRequestRepository budgetRepo,
            IAllocationRepository allocationRepo,
            IPaymentRepository paymentRepo)
        {
            _repo = repo;
            _requestTypeRepo = requestTypeRepo;
            _departmentRepo = departmentRepo;
            _fundingRepo = fundingRepo;
            _budgetRepo = budgetRepo;
            _allocationRepo = allocationRepo;
            _paymentRepo = paymentRepo;
        }

        public async Task<UserPermissions> GetPermissionsAsync(Guid userId)
            => await _repo.GetUserPermissionsAsync(userId);

        // فقط مواردی که کاربر دسترسی دارد را برمی‌گرداند
        public async Task<IEnumerable<UserEntityAccessDto>> GetUserRequestTypeAccessAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            var allRequestTypes = await _requestTypeRepo.GetAllAsync();
            
            // فقط مواردی که کاربر دسترسی دارد
            return allRequestTypes
                .Where(rt => perms.AllowedRequestTypeIds.Contains(rt.Id))
                .Select(rt => new UserEntityAccessDto
                {
                    EntityId = rt.Id,
                    EntityName = rt.Description,
                    CanView = perms.RequestTypeView,
                    CanCreate = perms.RequestTypeCreate,
                    CanEdit = perms.RequestTypeEdit,
                    CanDelete = perms.RequestTypeDelete
                });
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserRequestingDepartmentAccessAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            var allDepartments = await _departmentRepo.GetAllAsync();
            
            // فقط مواردی که کاربر دسترسی دارد
            return allDepartments
                .Where(d => perms.AllowedDepartmentIds.Contains(d.Id))
                .Select(d => new UserEntityAccessDto
                {
                    EntityId = d.Id,
                    EntityName = d.Description,
                    CanView = perms.RequestingDepartmentView,
                    CanCreate = perms.RequestingDepartmentCreate,
                    CanEdit = perms.RequestingDepartmentEdit,
                    CanDelete = perms.RequestingDepartmentDelete
                });
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserFundingSourceAccessAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            var allFundingSources = await _fundingRepo.GetAllAsync();
            
            // فقط مواردی که کاربر دسترسی دارد
            return allFundingSources
                .Where(f => perms.AllowedFundingSourceIds.Contains(f.Id))
                .Select(f => new UserEntityAccessDto
                {
                    EntityId = f.Id,
                    EntityName = f.Description,
                    CanView = perms.FundingSourceView,
                    CanCreate = perms.FundingSourceCreate,
                    CanEdit = perms.FundingSourceEdit,
                    CanDelete = perms.FundingSourceDelete
                });
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserBudgetRequestAccessAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            
            // اگر کاربر دسترسی View ندارد، لیست خالی برمی‌گردانیم
            if (!perms.BudgetRequestView)
                return Enumerable.Empty<UserEntityAccessDto>();

            var allBudgetRequests = await _budgetRepo.GetAllAsync();
            
            return allBudgetRequests.Select(br => new UserEntityAccessDto
            {
                EntityId = br.Id,
                EntityName = br.RequestTitle,
                CanView = perms.BudgetRequestView,
                CanCreate = perms.BudgetRequestCreate,
                CanEdit = perms.BudgetRequestEdit,
                CanDelete = perms.BudgetRequestDelete
            });
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserAllocationAccessAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            
            // اگر کاربر دسترسی View ندارد، لیست خالی برمی‌گردانیم
            if (!perms.AllocationView)
                return Enumerable.Empty<UserEntityAccessDto>();

            var allAllocations = await _allocationRepo.GetAllAsync();
            
            return allAllocations.Select(a => new UserEntityAccessDto
            {
                EntityId = a.Id,
                EntityName = a.Title,
                CanView = perms.AllocationView,
                CanCreate = perms.AllocationCreate,
                CanEdit = perms.AllocationEdit,
                CanDelete = perms.AllocationDelete
            });
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserPaymentAccessAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            
            // اگر کاربر دسترسی View ندارد، لیست خالی برمی‌گردانیم
            if (!perms.PaymentView)
                return Enumerable.Empty<UserEntityAccessDto>();

            var allPayments = await _paymentRepo.GetAllAsync();
            
            return allPayments.Select(p => new UserEntityAccessDto
            {
                EntityId = p.Id,
                EntityName = $"Payment {p.Id} - {p.PaymentAmount:C}",
                CanView = perms.PaymentView,
                CanCreate = perms.PaymentCreate,
                CanEdit = perms.PaymentEdit,
                CanDelete = perms.PaymentDelete
            });
        }

        // متدهای اضافی (اختیاری)
        public async Task<IEnumerable<UserEntityAccessDto>> GetUserPaymentMethodAccessAsync(Guid userId)
        {
            return await Task.FromResult(Enumerable.Empty<UserEntityAccessDto>());
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserAccessGroupAccessAsync(Guid userId)
        {
            return await Task.FromResult(Enumerable.Empty<UserEntityAccessDto>());
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserActionBudgetRequestAccessAsync(Guid userId)
        {
            return await Task.FromResult(Enumerable.Empty<UserEntityAccessDto>());
        }

        public async Task<IEnumerable<UserEntityAccessDto>> GetUserAllocationActionBudgetRequestAccessAsync(Guid userId)
        {
            return await Task.FromResult(Enumerable.Empty<UserEntityAccessDto>());
        }

        // متدهای قبلی (برای سازگاری)
        public async Task<IEnumerable<GetAllRequestTypeDto>> GetAllowedRequestTypesAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            var all = await _requestTypeRepo.GetAllAsync();
            return all.Where(r => perms.AllowedRequestTypeIds.Contains(r.Id))
                      .Select(r => new GetAllRequestTypeDto { Id = r.Id, Description = r.Description });
        }

        public async Task<IEnumerable<GetAllRequestingDepartmenDto>> GetAllowedDepartmentsAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            var all = await _departmentRepo.GetAllAsync();
            return all.Where(d => perms.AllowedDepartmentIds.Contains(d.Id))
                      .Select(d => new GetAllRequestingDepartmenDto { Id = d.Id, Description = d.Description });
        }

        public async Task<IEnumerable<GetAllFundingSourceDto>> GetAllowedFundingSourcesAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            var all = await _fundingRepo.GetAllAsync();
            return all.Where(f => perms.AllowedFundingSourceIds.Contains(f.Id))
                      .Select(f => new GetAllFundingSourceDto { Id = f.Id, Description = f.Description });
        }

        public async Task<IEnumerable<GetAllBudgetRequestDto>> GetAllowedBudgetRequestsAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            if (!perms.BudgetRequestView) return Enumerable.Empty<GetAllBudgetRequestDto>();
            var all = await _budgetRepo.GetAllAsync();
            var dtoMapper = new BudgetRequestToDtoMapper();
            return all.Select(entity => dtoMapper.ToGetAllDto(entity));
        }

        public async Task<IEnumerable<GetAllocationDto>> GetAllowedAllocationsAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            if (!perms.AllocationView) return Enumerable.Empty<GetAllocationDto>();
            var all = await _allocationRepo.GetAllAsync();
            return AllocationMapper.ToDtoList(all);
        }

        public async Task<IEnumerable<GetAllPaymentDto>> GetAllowedPaymentsAsync(Guid userId)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            if (!perms.PaymentView) return Enumerable.Empty<GetAllPaymentDto>();
            var all = await _paymentRepo.GetAllAsync();
            return all.Select(a => new GetAllPaymentDto()
            {
                Id = a.Id,
                PaymentDate = a.PaymentDate,
                PaymentAmount = a.PaymentAmount,
                AllocationId = a.AllocationId,
                PaymentMethodId = a.PaymentMethodId,
            });
        }

        public async Task<bool> CanAccessRequestTypeAsync(Guid userId, long id)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            return perms.AllowedRequestTypeIds.Contains(id);
        }

        public async Task<bool> CanAccessDepartmentAsync(Guid userId, long id)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            return perms.AllowedDepartmentIds.Contains(id);
        }

        public async Task<bool> CanAccessFundingSourceAsync(Guid userId, long id)
        {
            var perms = await _repo.GetUserPermissionsAsync(userId);
            return perms.AllowedFundingSourceIds.Contains(id);
        }
    }
}
