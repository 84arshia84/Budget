using Application.Dto.Payment;
using Application.Dto.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.PaymentMethod
{
    public class UpdatePaymentMethodDtoValidator
    {
        public void Validate(UpdatePaymentMethodDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.title))
                 throw new ArgumentException("نام روش پرداخت الزامی است.");
        }
    }
}
