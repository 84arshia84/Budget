using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Allocation
{
    public class GetAllocationDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public long BudgetRequestId { get; set; }
        public List<ActionAllocationDto> ActionAllocations { get; set; } = new();
    }
}
