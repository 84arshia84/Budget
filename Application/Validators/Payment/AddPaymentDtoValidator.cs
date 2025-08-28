using Application.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Allocation;
using Domain.AllocationActionBudgetRequest;
using Application.Contracts;
using Domain.Payment;
using Application.Services;

namespace Application.Validators.Payment
{
    public class AddPaymentDtoValidator
    {
        private readonly IAllocationService _allocationService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentMethodService _paymentMethodService;

        public AddPaymentDtoValidator(
            IAllocationService allocationService,
            IPaymentRepository paymentRepository,
            IPaymentMethodService paymentMethodService)

        {
            _allocationService = allocationService;
            _paymentRepository = paymentRepository;
            _paymentMethodService = paymentMethodService;

        }

        public async Task ValidateAsync(AddPaymentDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.PaymentAmount <= 0)
                throw new ArgumentException("مبلغ پرداخت باید بزرگ‌تر از صفر باشد.");

            if (dto.AllocationId <= 0)
                throw new ArgumentException("شناسه تخصیص معتبر نیست.");

            if (dto.PaymentMethodId <= 0)
                throw new ArgumentException("شناسه روش پرداخت معتبر نیست.");

            // 1️⃣ دریافت تخصیص
            var allocationDto = await _allocationService.GetById(dto.AllocationId);
            if (allocationDto == null)
                throw new ArgumentException($"تخصیص با شناسهٔ {dto.AllocationId} یافت نشد.");

            // 2️⃣ محاسبه مجموع کل بودجه تخصیص داده شده
            var totalAllocated = allocationDto.ActionAllocations.Sum(x => x.BudgetAmountPeriod);

            // 3️⃣ محاسبه مجموع پرداخت‌های قبلی
            var totalPaid = await _paymentRepository.GetTotalPaymentsByAllocationId(dto.AllocationId);

            // 4️⃣ محاسبه مانده بودجه
            var remaining = totalAllocated - totalPaid;

            // 5️⃣ چک نهایی: آیا پرداخت جدید بیش از مانده است؟
            if (dto.PaymentAmount > remaining)
            {
                throw new ArgumentException(
                    $"مبلغ پرداخت ({dto.PaymentAmount}) نمی‌تواند بیشتر از ماندهٔ بودجه ({remaining}) باشد. ");
            }

            var paymentMethod = await _paymentMethodService.GetByIdAsync(dto.PaymentMethodId);
            if (paymentMethod == null)
            {
                throw new KeyNotFoundException($"متد پرداخت با شناسه {dto.PaymentMethodId} یافت نشد.");
            }

        }
    }
}
    

