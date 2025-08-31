using Domain.FundingSource;
using Domain.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _Context;

        public PaymentRepository(AppDbContext context)
        {
            _Context = context;
        }

        public  async Task AddAsync(Payment payment)
        {
           _Context.Payments .AddAsync(payment);
           await _Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var type = await _Context.Payments.FindAsync(id);
            if (type != null)
            {
                _Context.Payments.Remove(type);
                await _Context.SaveChangesAsync();
            }

        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _Context.Payments.ToListAsync();
        }

        public async Task<Payment> GetById(long id)
        {
            return await _Context.Payments.FindAsync(id);
        }

        public async Task UpdateAsync(Payment payment)
        {
            _Context.Payments.Update(payment);
            await _Context.SaveChangesAsync();
        }
        public async Task<decimal> GetTotalPaymentsByAllocationId(long allocationId)
        {
            return await _Context.Payments
                .Where(p => p.AllocationId == allocationId)
                .SumAsync(p => p.PaymentAmount);
        }
    }
}
