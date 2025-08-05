using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.ActionBudgetRequest;
using Application.Dto.BudgetRequest;
using Application.Mapper;
using Domain.BudgetRequest;
using Domain.FundingSource;
using Domain.RequestingDepartment;
using Domain.RequestType;

namespace Application.Services
{
    public class BudgetRequestService : IBudgetRequestService
    {
        private readonly IBudgetRequestRepository _repository;

        public BudgetRequestService(IBudgetRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsyinc(AddBudgetRequestDto dto)
        {
            // مرحله 1: درخواست اصلی رو مپ کن و ذخیره کن
            BudgetRequestMapper budgetRequestMapper = new BudgetRequestMapper();
            var budgetRequestEntity = budgetRequestMapper.DtoTomodelMapper(dto);

            await _repository.AddAsync(budgetRequestEntity); // اینجا Id ساخته می‌شه

            // اگر لیست اقدامات خالی یا null باشه، ادامه نده
            if (dto.ActionBudgetRequests == null || !dto.ActionBudgetRequests.Any())
                return;

            // مرحله 2: اقدامات رو مپ کن
            ActionBudgetRequestMapper actionMapper = new ActionBudgetRequestMapper();
            var actionEntities = actionMapper.DtoToModelMapper(dto.ActionBudgetRequests);

            // مرحله 3: به همه اقدامات، BudgetRequestId رو اختصاص بده
            foreach (var action in actionEntities)
            {
                action.BudgetRequestId = budgetRequestEntity.Id;
            } 

            // مرحله 4: اقدامات رو به دیتابیس اضافه کن
            await _repository.AddRangeAsync(actionEntities);
        }

        public Task DeleteAsyinc(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ICollection<GetAllBudgetRequestDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetByIdBudgetRequestDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsyinc(UpdateBudgetRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
