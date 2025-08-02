using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestingDepartment
{
    public class RequestingDepartment
    {
        public long id { get; set; }
        public string Description { get; set; }
        public ICollection<BudgetRequest.BudgetRequest> BudgetRequests { get; set; }
    }
}
