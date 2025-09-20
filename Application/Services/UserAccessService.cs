using Application.Contracts;
using Application.Dto.Allocation;
using Application.Dto.BudgetRequest;
using Application.Dto.FundingSource;
using Application.Dto.Payment;
using Application.Dto.RequestingDepartmen;
using Application.Dto.RequestType;
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

            // --- اضافه کردن این خط برای تبدیل Domain به DTO ---
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