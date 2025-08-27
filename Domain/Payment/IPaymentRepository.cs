using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payment
{
    public interface IPaymentRepository
    {

        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(long id);
        Task<List<Payment>> GetAllAsync();
        Task<Payment> GetById(long id);
        Task<decimal> GetTotalPaymentsByAllocationId(long allocationId);
    }
}
