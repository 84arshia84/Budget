using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Payment
{
    public class GetByIdPaymentDto
    {
        public long Id { get; set; }
        public DateTime PaymentDate { get; set; } // تاریخ پرداخت
        public decimal PaymentAmount { get; set; } // مبلغ پرداخت
        public long AllocationId { get; set; } // تخصیص مرتبط
        public long PaymentMethodId { get; set; } // روش پرداخت
    }
}
