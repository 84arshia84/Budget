using Application.Dto.ActionBudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.BudgetRequest
{
    public class GetByIdBudgetRequestDto
    {
        public long Id { get; set; }
        public string RequestTitle { get; set; }
        public long RequestingDepartmentId { get; set; }
        public long RequestTypeId { get; set; }
        public long FundingSourceId { get; set; }
        public int year { get; set; }
        public string ServiceDescription { get; set; }
        public string budgetEstimationRanges { get; set; }
        public List<ActionBudgetRequestDto> ActionBudgetRequests { get; set; }
    }
}
