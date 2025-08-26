using Application.Dto.BudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.BudgetRequest
{
    public class AddBudgetRequestDtoValidator
    {
        public void Validate(AddBudgetRequestDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.RequestTitle))
                throw new ArgumentException("عنوان درخواست بودجه نمی‌تواند خالی باشد.");

            if (dto.RequestingDepartmentId <= 0)
                throw new ArgumentException("شناسه دپارتمان درخواست‌کننده معتبر نیست.");

            if (dto.RequestTypeId <= 0)
                throw new ArgumentException("شناسه نوع درخواست معتبر نیست.");

            if (dto.FundingSourceId <= 0)
                throw new ArgumentException("شناسه منبع مالی معتبر نیست.");

            if (dto.year < 2000 || dto.year > 2100)
                throw new ArgumentException("سال وارد شده معتبر نیست.");

            if (string.IsNullOrWhiteSpace(dto.ServiceDescription))
                throw new ArgumentException("توضیحات خدمت الزامی است.");

            if (dto.ActionBudgetRequests == null || dto.ActionBudgetRequests.Count == 0)
                throw new ArgumentException("حداقل یک آیتم ActionBudgetRequest باید وارد شود.");

            var actionValidator = new ActionBudgetRequestDtoValidator();
            foreach (var action in dto.ActionBudgetRequests)
            {
                actionValidator.Validate(action);
            }
        }
    }
}
