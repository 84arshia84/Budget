using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.ActionBudgetRequest
{
    public class ActionBudgetRequestDto
    {
        public string Description { get; set; }

        public List<BudgetAmountPeriodDto> BudgetAmountPeriod { get; set; } = new();

    }
}
