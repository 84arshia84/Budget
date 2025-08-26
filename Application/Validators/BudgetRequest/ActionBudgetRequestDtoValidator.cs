using Application.Dto.ActionBudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.BudgetRequest
{
    public class ActionBudgetRequestDtoValidator
    {
        public void Validate(ActionBudgetRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentException("توضیحات درخواست عملیاتی بودجه الزامی است.");

            if (dto.BudgetAmountPeriod == null || dto.BudgetAmountPeriod.Count == 0)
                throw new ArgumentException("حداقل یک بازه بودجه باید وارد شود.");

            var periodValidator = new BudgetAmountPeriodDtoValidator();
            foreach (var period in dto.BudgetAmountPeriod)
            {
                periodValidator.Validate(period);
            }
        }
    }
}
