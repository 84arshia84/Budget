using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.AccessGroup;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class AccessGroupRepository : IAccessGroupRepository
    {

        private readonly AppDbContext _Context;

        public AccessGroupRepository (AppDbContext context)
        {
            _Context = context;
        }

        public async Task AddAsync(AccessGroup accessGroup)
        {
            await _Context.AccessGroups.AddAsync(accessGroup);
            await _Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _Context.AccessGroups.FindAsync(id);
            if (entity != null)
            {
                _Context.AccessGroups.Remove(entity);
                await _Context.SaveChangesAsync();
            }
        }
        public async Task<List<AccessGroup>> GetAllAsync()
        {
            return await _Context.AccessGroups
                .Include(x => x.Users)
                .Include(x => x.RequestTypes)
                .Include(x => x.RequestingDepartments)
                .Include(x => x.FundingSources)
                .Include(x => x.Properties)
                .ToListAsync();
        }

        public async Task<AccessGroup> GetByIdAsync(long id)
        {
            return await _Context.AccessGroups
                .Include(x => x.Users)
                .Include(x => x.RequestTypes)
                .Include(x => x.RequestingDepartments)
                .Include(x => x.FundingSources)
                .Include(x => x.Properties)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(AccessGroup accessGroup)
        {
            _Context.AccessGroups.Update(accessGroup);
            await _Context.SaveChangesAsync();
        }
    }
}
