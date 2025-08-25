using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Payment;

namespace Application.Contracts
{
    public interface IPaymentService
    {
        Task AddAsync (AddPaymentDto dto);
        Task DeleteAsync (long id);
        Task UpdateAsync (long id,UpdatePaymentDto  dto);
        Task<List<GetAllPaymentDto>> GetAllAsync ();
        Task<GetByIdPaymentDto> GetByIdAsync(long id);
    }
}
