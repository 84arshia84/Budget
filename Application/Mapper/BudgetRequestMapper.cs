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
       
        public BudgetRequest DtoTomodelMapper(AddBudgetRequestDto dto)
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

    }
}
