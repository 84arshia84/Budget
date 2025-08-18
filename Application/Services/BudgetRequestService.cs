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
        private readonly BudgetRequestMapper _mapper;
        private readonly BudgetRequestToDtoMapper _dtoMapper;
        private readonly ActionBudgetRequestMapper _actionMapper;

        public BudgetRequestService(
            IBudgetRequestRepository repository,
            BudgetRequestMapper mapper,
            BudgetRequestToDtoMapper dtoMapper,
            ActionBudgetRequestMapper actionMapper)
        {
            _repository = repository;
            _mapper = mapper;
            _dtoMapper = dtoMapper;
            _actionMapper = actionMapper;
        }

        public async Task AddAsyinc(AddBudgetRequestDto dto)
        {
            var budgetRequestEntity = _mapper.ToEntity(dto);
            await _repository.AddAsync(budgetRequestEntity);

            if (dto.ActionBudgetRequests == null || !dto.ActionBudgetRequests.Any())
                return;

            var actionEntities = _actionMapper.ToEntity(dto.ActionBudgetRequests);

            foreach (var action in actionEntities)
                action.BudgetRequestId = budgetRequestEntity.Id;

            await _repository.AddRangeAsync(actionEntities);
        }

        public async Task DeleteAsyinc(long id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                throw new KeyNotFoundException($"بودجه درخواستی با شناسه {id} یافت نشد.");

            await _repository.DeleteAsync(id.ToString());
        }

        public async Task<List<GetAllBudgetRequestDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => _dtoMapper.ToGetAllDto(e)).ToList();
        }

        public async Task<GetByIdBudgetRequestDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null) return null;

            return _dtoMapper.ToGetByIdDto(entity);
        }

        public async Task UpdateAsyinc(long id, UpdateBudgetRequestDto dto)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                throw new KeyNotFoundException($"بودجه درخواستی با شناسه {id} یافت نشد.");

            _mapper.UpdateEntity(dto, entity);
            await _repository.UpdateAsync(entity);
        }
    }
}
