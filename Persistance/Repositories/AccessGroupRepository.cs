using Domain.AccessGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class AccessGroupRepository : IAccessGroupRepository
    {
        private readonly AppDbContext _context;

        public AccessGroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AccessGroup entity)
        {
            _context.AccessGroups.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AccessGroup entity)
        {
            _context.AccessGroups.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.AccessGroups.FindAsync(id);
            if (entity != null)
            {
                _context.AccessGroups.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AccessGroup> GetByIdAsync(long id)
        {
            return await _context.AccessGroups
                .Include(x => x.Properties)
                .Include(x => x.Users)
                .Include(x => x.RequestTypes)
                .Include(x => x.RequestingDepartments)
                .Include(x => x.FundingSources)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AccessGroup>> GetAllAsync()
        {
            return await _context.AccessGroups
                .Include(x => x.Properties)
                .Include(x => x.Users)
                .Include(x => x.RequestTypes)
                .Include(x => x.RequestingDepartments)
                .Include(x => x.FundingSources)
                .ToListAsync();
        }
    }
}
