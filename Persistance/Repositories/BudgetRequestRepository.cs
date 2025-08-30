using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.ActionBudgetRequestEntity;
using Domain.BudgetRequest;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class BudgetRequestRepository : IBudgetRequestRepository
    {
        private readonly AppDbContext _context;

        public BudgetRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BudgetRequest budgetRequest)
        {
            await _context.BudgetRequests.AddAsync(budgetRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BudgetRequest budgetRequest)
        {
            _context.BudgetRequests.Update(budgetRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.BudgetRequests.FindAsync(id);
            if (entity != null)
            {
                _context.BudgetRequests.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BudgetRequest>> GetAllAsync()
        {
            return await _context.BudgetRequests
                .Include(b => b.ActionBudgetRequestEntity)
                .ToListAsync();
        }

        public async Task<BudgetRequest> GetById(long id)
        {
            return await _context.BudgetRequests
                .Include(b => b.ActionBudgetRequestEntity)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddRangeAsync(IEnumerable<ActionBudgetRequestEntity> entities)
        {
            await _context.ActionBudgetRequestEntitys.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveActionsByRequestId(long requestId)
        {
            var existing = _context.ActionBudgetRequestEntitys
                .Where(a => a.BudgetRequestId == requestId);

            _context.ActionBudgetRequestEntitys.RemoveRange(existing);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<dynamic>> GetAllTotalActionBudgetDynamicAsync()
        {
            using (var connection = _context.Database.GetDbConnection())
            {
                return await connection.QueryAsync("dbo.sp_GetAllRequestsWithTotalBudget",
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
