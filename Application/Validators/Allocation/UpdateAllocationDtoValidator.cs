using Application.Dto.Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Allocation
{
    public class UpdateAllocationDtoValidator
    {
        public void Validate(UpdateAllocationDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("عنوان تخصیص الزامی است.");

            if (dto.Date > DateTime.Now)
                throw new ArgumentException("تاریخ تخصیص نمی‌تواند در آینده باشد.");

            if (dto.BudgetRequestId <= 0)
                throw new ArgumentException("شناسه درخواست بودجه معتبر نیست.");

            if (dto.ActionAllocations == null || !dto.ActionAllocations.Any())
                throw new ArgumentException("حداقل یک Action تخصیص باید وارد شود.");

            var actionValidator = new ActionAllocationDtoValidator();
            foreach (var action in dto.ActionAllocations)
            {
                actionValidator.Validate(action);
            }
        }
    }
}
