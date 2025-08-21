using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AllocationActionBudgetRequest
{
    public class AllocationActionBudgetRequest
    {
        public long AllocationId { get; set; }
        public Allocation.Allocation Allocation { get; set; }
        public long ActionBudgetRequestEntityId { get; set; } 
        public ActionBudgetRequestEntity.ActionBudgetRequestEntity ActionBudgetRequestEntity { get; set; }
        public Decimal AllocatedAmount { get; set; } 

    }
}
