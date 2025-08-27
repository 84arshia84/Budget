using Application.Contracts;
using Application.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Payment;
using Domain.Allocation;
using Domain.PaymentMethod;
using Application.Dto.PaymentMethod;
using Application.Validators.Allocation;
using Application.Validators.Payment;
using Domain.AllocationActionBudgetRequest;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _repository;
        private readonly IAllocationService _allocationService;
        public PaymentService (IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(AddPaymentDto dto)
        {

            var allocation = await _allocationService.GetById(dto.AllocationId);
            
            var validator = new AddPaymentDtoValidator();
            validator.Validate(dto,allocation);

            var entity = new Payment()
            {
                PaymentDate = dto.PaymentDate,
                PaymentAmount = dto.PaymentAmount,
                AllocationId = dto.AllocationId,
                PaymentMethodId = dto.PaymentMethodId,
            };
            await _repository.AddAsync(entity);

        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllPaymentDto>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();

            return entity.Select(a => new GetAllPaymentDto()
            {
                Id = a.Id,
                PaymentDate = a.PaymentDate,
                PaymentAmount = a.PaymentAmount,
                AllocationId = a.AllocationId,
                PaymentMethodId = a.PaymentMethodId,


            }).ToList();
        }

        public async Task<GetByIdPaymentDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                return null;
            return new GetByIdPaymentDto()
            {
                Id = entity.Id,
                PaymentDate = entity.PaymentDate,
                PaymentAmount = entity.PaymentAmount,
                AllocationId = entity.AllocationId,
                PaymentMethodId = entity.PaymentMethodId,
            };
        }

        public async Task UpdateAsync(long id ,UpdatePaymentDto dto)
        {
            var validator = new UpdatePaymentDtoValidator();
            validator.Validate(dto);

            var entity = await _repository.GetById(id);
            if (entity == null)
                throw new KeyNotFoundException($"پرداخت با شناسه {id} یافت نشد  ");
            
            entity.PaymentDate = dto.PaymentDate;
            entity.PaymentAmount = dto.PaymentAmount;
            entity.AllocationId = dto.AllocationId;
            entity.PaymentMethodId = dto.PaymentMethodId;
            await _repository.UpdateAsync(entity);
        }
    }
}
