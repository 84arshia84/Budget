using Domain.Allocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.AllocationActionBudgetRequest;

namespace Persistance.Repositories
{
    public class AllocationRepository : IAllocationRepository
    {
        private readonly AppDbContext _context;

        public AllocationRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Allocation allocation)
        {
            await _context.Allocations.AddAsync(allocation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long Id)
        {
            var type = await _context.Allocations.FindAsync(Id);
            if (type != null)
            {
                _context.Allocations.Remove(type);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Allocation>> GetAllAsync()
        {
            return await _context.Allocations
                .Include(a => a.AllocationActionBudgetRequests)
                .ToListAsync();
        }
        public async Task<Allocation> GetByIdAsync(long Id)
        {
            return await _context.Allocations
                .Include(a => a.AllocationActionBudgetRequests)
                .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task UpdateAsync(Allocation allocation)
        {
            var existing = await _context.Allocations
                .Include(a => a.AllocationActionBudgetRequests)
                .FirstOrDefaultAsync(a => a.Id == allocation.Id);

            if (existing == null)
                throw new KeyNotFoundException("Allocation not found");

            existing.Title = allocation.Title;
            existing.Date = allocation.Date;
            existing.BudgetRequestId = allocation.BudgetRequestId;

            // حذف قدیمی‌ها
            _context.AllocationActionBudgetRequests.RemoveRange(existing.AllocationActionBudgetRequests);

            // اضافه کردن جدیدها
            foreach (var actionAlloc in allocation.AllocationActionBudgetRequests)
            {
                existing.AllocationActionBudgetRequests.Add(new AllocationActionBudgetRequest
                {
                    ActionBudgetRequestEntityId = actionAlloc.ActionBudgetRequestEntityId,
                    AllocatedAmount = actionAlloc.AllocatedAmount
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
