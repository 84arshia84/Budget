using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.BudgetRequest;
using Domain.BudgetRequest;

namespace Application.Mapper
{
    public class BudgetRequestMapper
    {

        public BudgetRequest ToEntity(AddBudgetRequestDto dto)
        {
            var entity = new BudgetRequest()
            {
                RequestTitle = dto.RequestTitle,
                RequestingDepartmentId = dto.RequestingDepartmentId,
                RequestTypeId = dto.RequestTypeId,
                FundingSourceId = dto.FundingSourceId,
                year = dto.year,
                ServiceDescription = dto.ServiceDescription,
                budgetEstimationRanges = dto.budgetEstimationRanges,
            };
            return entity;
        }
        public void UpdateEntity(UpdateBudgetRequestDto dto, BudgetRequest entity)
        {
            entity.RequestTitle = dto.RequestTitle;
            entity.RequestingDepartmentId = dto.RequestingDepartmentId;
            entity.RequestTypeId = dto.RequestTypeId;
            entity.FundingSourceId = dto.FundingSourceId;
            entity.year = dto.year;
            entity.ServiceDescription = dto.ServiceDescription;
            entity.budgetEstimationRanges = dto.budgetEstimationRanges;
        }
    }
}
