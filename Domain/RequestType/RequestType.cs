using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestType
{
    public class RequestType
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public ICollection<BudgetRequest.BudgetRequest> BudgetRequests { get; set; }
    }
}
