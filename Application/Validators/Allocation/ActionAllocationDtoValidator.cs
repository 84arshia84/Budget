using Application.Dto.Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Allocation
{
    public class ActionAllocationDtoValidator
    {
        public void Validate(ActionAllocationDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.ActionBudgetRequestId <= 0)
                throw new ArgumentException("شناسه ActionBudgetRequest معتبر نیست.");

            if (dto.BudgetAmountPeriod <= 0)
                throw new ArgumentException("مبلغ تخصیص باید بزرگ‌تر از صفر باشد.");
        }
    }
}
