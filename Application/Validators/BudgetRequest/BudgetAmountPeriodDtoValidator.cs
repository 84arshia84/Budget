using Application.Dto.ActionBudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.BudgetRequest
{
    public class BudgetAmountPeriodDtoValidator
    {
        public void Validate(BudgetAmountPeriodDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.EstimationRange))
                throw new ArgumentException("بازه تخمینی الزامی است.");

            if (string.IsNullOrWhiteSpace(dto.RequestedAmount))
                throw new ArgumentException("مبلغ درخواستی الزامی است.");

            if (string.IsNullOrWhiteSpace(dto.PlannedAmount))
                throw new ArgumentException("مبلغ برنامه‌ریزی شده الزامی است.");
        }
    }
}
