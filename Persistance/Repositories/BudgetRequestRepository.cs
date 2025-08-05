using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BudgetRequest;

namespace Persistance.Repositories
{
    public class BudgetRequestRepository : IBudgetRequestRepository
    {
        private readonly AppDbContext _context;

        public BudgetRequestRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BudgetRequest budgetRequest)
        {
            await _context.BudgetRequests.AddAsync(budgetRequest);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(string id)
        {
            var BudgetRequest = await _context.BudgetRequests.FindAsync(id);
            if (BudgetRequest != null)
            {
                _context.BudgetRequests.Remove(BudgetRequest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BudgetRequest>> GetAllAsync()
        {
            return _context.BudgetRequests.ToList();
        }

        public async Task<BudgetRequest> GetById(long id)
        {
            return await _context.BudgetRequests.FindAsync(id);
        }

        public async Task UpdateAsync(BudgetRequest budgetRequest)
        {
            _context.BudgetRequests.Update(budgetRequest);
            await _context.SaveChangesAsync();

        }
    }
}
