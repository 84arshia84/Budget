using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.FundingSource;
using Application.Dto.PaymentMethod;
using Application.Validators.Allocation;
using Application.Validators.PaymentMethod;
using Domain.PaymentMethod;

namespace Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _repository;

        public PaymentMethodService(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(AddPaymentMethodDto dto)
        {
            var validator = new AddPaymentMethodDtoValidator();
            validator.Validate(dto);

            var entity = new PaymentMethod()
            {
                title = dto.title
            };
            await _repository.AddAsync(entity);
        }
        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task<List<GetAllPaymentMethodDto>> GetAllAsync()
        {

            var entity = await _repository.GetAllAsync();

            return entity.Select(a => new GetAllPaymentMethodDto()
            {
                Id = a.Id,
                title = a.title

            }).ToList();
        }
        public async Task<GetByIdPaymentMethodDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return null;
            return new GetByIdPaymentMethodDto
            {
                Id = entity.Id,
                title = entity.title

            };
        }
        public async Task UpdateAsync(long id, UpdatePaymentMethodDto dto)
        {
            var validator = new UpdatePaymentMethodDtoValidator();
            validator.Validate(dto);

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
               throw new KeyNotFoundException($"تخصیص با شناسه {id} یافت نشد  ");
            entity.title = dto.title;
            await _repository.UpdateAsync(entity);

        }
    }
}
