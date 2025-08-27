using Application.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Allocation;
using Domain.AllocationActionBudgetRequest;

namespace Application.Validators.Payment
{
    public class AddPaymentDtoValidator
    {
        public void Validate(AddPaymentDto paymentDto , GetAllocationDto allocationDto)
        {
            if (paymentDto == null)
                throw new ArgumentNullException(nameof(paymentDto));

            if (paymentDto.PaymentAmount <= 0)
                throw new ArgumentException("مبلغ پرداخت باید بزرگ‌تر از صفر باشد.");

            if (paymentDto.AllocationId <= 0)
                throw new ArgumentException("شناسه تخصیص معتبر نیست.");

            if (paymentDto.PaymentMethodId <= 0)
                throw new ArgumentException("شناسه روش پرداخت معتبر نیست.");
            if (paymentDto.PaymentAmount > allocationDto.ActionAllocations.Sum((x=>x.BudgetAmountPeriod))) throw new ArgumentException("عدد وارد شده نمیتواند بزرگ تر از عدد تخصیص باشد ");

            
        }
    }
}

