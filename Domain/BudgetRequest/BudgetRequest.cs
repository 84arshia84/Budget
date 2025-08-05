using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BudgetRequest
{
    public class BudgetRequest
    {
        public long Id { get; set; }
        public string RequestTitle { get; set; }
        public long RequestingDepartmentId { get; set; }
        public long RequestTypeId { get; set; }
        public long FundingSourceId { get; set; }
        public int year { get; set; }
        public string ServiceDescription { get; set; }
        public string budgetEstimationRanges { get; set; }

        public ICollection<ActionBudgetRequestEntity.ActionBudgetRequestEntity>  ActionBudgetRequestEntity { get; set; }
        public RequestType.RequestType RequestType { get; set; }
        public RequestingDepartment.RequestingDepartment RequestingDepartment { get; set; }
        public FundingSource.FundingSource FundingSource { get; set; }

    }
}
