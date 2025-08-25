using Domain.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly AppDbContext _context;

        public PaymentMethodRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethod.AddAsync(paymentMethod);
            await _context.SaveChangesAsync();
        }

       
        public async Task DeleteAsync(long Id)
        {
            var type = await _context.PaymentMethod.FindAsync(Id);
            if (type != null)
            {
                _context.PaymentMethod.Remove(type);
                await _context.SaveChangesAsync();
            }


        }

        public async Task<List<PaymentMethod>> GetAllAsync()
        {
            return await _context.PaymentMethod.ToListAsync();
        }

        public async Task<PaymentMethod> GetByIdAsync(long Id)
        {
            return await _context.PaymentMethod.FindAsync(Id);
        }

        public async Task UpdateAsync(PaymentMethod paymentMethod)
        {
            _context.PaymentMethod.UpdateRange(paymentMethod);
            await _context.SaveChangesAsync();
        }
    }
}
