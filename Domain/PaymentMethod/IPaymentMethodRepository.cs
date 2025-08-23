using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PaymentMethod
{
    public interface IPaymentMethodRepository
    {
        Task AddAsync(PaymentMethod paymentMethod);
        Task UpdateAsync(PaymentMethod paymentMethod);
        Task DeleteAsync(long Id);
        Task<List<PaymentMethod>> GetAllAsync();
        Task<PaymentMethod> GetByIdAsync(long Id);
    }
}
