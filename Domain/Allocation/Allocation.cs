using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Allocation
{
    public class Allocation
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public long BudgetRequestId { get; set; }
        public BudgetRequest.BudgetRequest BudgetRequest { get; set; }
        public List<AllocationActionBudgetRequest.AllocationActionBudgetRequest> AllocationActionBudgetRequests { get; set; } = new(); // لیستی از روابط بین این تخصیص و درخواست‌های عملیاتی


    }
}
