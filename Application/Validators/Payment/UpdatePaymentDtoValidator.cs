using Application.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Payment
{
    public class UpdatePaymentDtoValidator
    {
        public void Validate(AddPaymentDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.PaymentDate > DateTime.Now)
                throw new ArgumentException("تاریخ پرداخت نمی‌تواند در آینده باشد.");

            if (dto.PaymentAmount <= 0)
                throw new ArgumentException("مبلغ پرداخت باید بزرگ‌تر از صفر باشد.");

            if (dto.AllocationId <= 0)
                throw new ArgumentException("شناسه تخصیص معتبر نیست.");

            if (dto.PaymentMethodId <= 0)
                throw new ArgumentException("شناسه روش پرداخت معتبر نیست.");
        }
    }
}
