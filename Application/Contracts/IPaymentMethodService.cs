using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.PaymentMethod;

namespace Application.Contracts
{
    public interface IPaymentMethodService
    {
        Task AddAsync(AddPaymentMethodDto dto);
        Task UpdateAsync(long id, UpdatePaymentMethodDto dto);
        Task DeleteAsync(long id);
        Task<List<GetAllPaymentMethodDto>> GetAllAsync();
        Task <GetByIdPaymentMethodDto> GetByIdAsync(long id);

    }
}
