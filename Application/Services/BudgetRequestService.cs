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
            BudgetRequestMapper mapper = new BudgetRequestMapper();
            var entity=  mapper.DtoTomodelMapper(dto);
            BudgetRequest budget = new BudgetRequest();
            await _repository.AddAsync(budget);
            
            ActionBudgetRequestMapper actionMapper = new ActionBudgetRequestMapper();
            var ActionBudgetRequestEntity = actionMapper.DtoTomodelMapper(dto.ActionBudgetRequests);



        }
    }
}
