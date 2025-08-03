using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FundingSource
{
    public class FundingSource
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ICollection<BudgetRequest.BudgetRequest> BudgetRequests { get; set; }
    }
}
