using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.FundingSource;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class FundingSourceRepository : IFundingSourceRepository
    {
        private readonly AppDbContext _context;

        public FundingSourceRepository (AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FundingSource fundingSource)
        {
            _context.FundingSources.AddAsync(fundingSource);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var type = await _context.FundingSources.FindAsync(id);
            if (type != null)
            {
                _context.FundingSources.Remove(type);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<FundingSource>> GetAllAsync()
        {
           return await _context.FundingSources.ToListAsync();
        }

        public async Task<FundingSource> GetById(long id)
        {
            return await _context.FundingSources.FindAsync(id);
        }

        public async Task UpdateAsync(FundingSource fundingSource)
        {
            _context.FundingSources.Update(fundingSource);
             await _context.SaveChangesAsync();
        }
    }
}
