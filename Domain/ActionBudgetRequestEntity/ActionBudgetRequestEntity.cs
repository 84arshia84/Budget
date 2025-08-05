using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ActionBudgetRequestEntity
{
    public class ActionBudgetRequestEntity
    {
        public long Id { get; set; }
        public string Description { get; set; }
       public long BudgetRequestId { get; set; }
       public string BudgetAmountPeriod { get; set; }

       public BudgetRequest.BudgetRequest BudgetRequest{ get; set; }

}
}
