
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.Allocation;
using Application.Mapper.Allocation;
using Application.Validators.Allocation;
using Domain.Allocation;
using Domain.AllocationActionBudgetRequest;

namespace Application.Services
{
    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository _repository;

        public AllocationService(IAllocationRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CreateAllocationDto dto)
        {
            var validator = new AllocationValidator();
            validator.Validator(dto);
            validator.Validator(dto.ActionAllocations);
            var allocation = AllocationMapper.ToEntity(dto);
            await _repository.AddAsync(allocation);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllocationDto>> GetAllAsync()
        {
            var allocations = await _repository.GetAllAsync();
            return AllocationMapper.ToDtoList(allocations);
        }

        public async Task<GetAllocationDto> GetById(long id)
        {
            var allocation = await _repository.GetByIdAsync(id);
            return allocation == null ? null : AllocationMapper.ToDto(allocation);
        }

        public async Task UpdateAsync(long id, UpdateAllocationDto dto)
        {

            var validator = new AllocationValidator();
            validator.Validator(dto);
            validator.Validator(dto.ActionAllocations);

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Allocation {id} not found.");

            // آپدیت فیلدهای اصلی
            existing.Title = dto.Title;
            existing.Date = dto.Date;
            existing.BudgetRequestId = dto.BudgetRequestId;

            // 👇 پاک کردن Action های قبلی از دیتابیس
            await _repository.RemoveActionsByAllocationId(existing.Id);

            // 👇 اضافه کردن Action های جدید
            existing.AllocationActionBudgetRequests = dto.ActionAllocations
                .Select(item => new AllocationActionBudgetRequest
                {
                    AllocationId = existing.Id, // 👈 مهم
                    ActionBudgetRequestEntityId = item.ActionBudgetRequestId,
                    AllocatedAmount = item.BudgetAmountPeriod
                }).ToList();

            await _repository.UpdateAsync(existing);
        }
    }
}
