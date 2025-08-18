using Application.Dto.ActionBudgetRequest;
using Application.Dto.BudgetRequest;
using Domain.BudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class BudgetRequestToDtoMapper
    {
        public GetByIdBudgetRequestDto ToGetByIdDto(BudgetRequest entity)
        {
            return new GetByIdBudgetRequestDto
            {
                Id = entity.Id,
                RequestTitle = entity.RequestTitle,
                RequestingDepartmentId = entity.RequestingDepartmentId,
                RequestTypeId = entity.RequestTypeId,
                FundingSourceId = entity.FundingSourceId,
                year = entity.year,
                ServiceDescription = entity.ServiceDescription,
                budgetEstimationRanges = entity.budgetEstimationRanges,
                ActionBudgetRequests = entity.ActionBudgetRequestEntity?.Select(a => new ActionBudgetRequestDto
                {
                    Description = a.Description,
                    BudgetAmountPeriod = JsonSerializer.Deserialize<List<BudgetAmountPeriodDto>>(a.BudgetAmountPeriod)
                }).ToList()
            };
        }

        public GetAllBudgetRequestDto ToGetAllDto(BudgetRequest entity)
        {
            return new GetAllBudgetRequestDto
            {
                Id = entity.Id,
                RequestTitle = entity.RequestTitle,
                RequestingDepartmentId = entity.RequestingDepartmentId,
                RequestTypeId = entity.RequestTypeId,
                FundingSourceId = entity.FundingSourceId,
                year = entity.year,
                ServiceDescription = entity.ServiceDescription,
                budgetEstimationRanges = entity.budgetEstimationRanges,
                ActionBudgetRequests = entity.ActionBudgetRequestEntity?.Select(a => new ActionBudgetRequestDto
                {
                    Description = a.Description,
                    BudgetAmountPeriod = JsonSerializer.Deserialize<List<BudgetAmountPeriodDto>>(a.BudgetAmountPeriod)
                }).ToList()
            };
        }
    }
}
