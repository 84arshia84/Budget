using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.RequestType;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly AppDbContext _context;

        public RequestTypeRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(RequestType requestType)
        {
            _context.RequestTypes.Add(requestType);
            await _context.SaveChangesAsync();
        }
         
        public async Task DeleteAsync(long id)
        {
            var type = await _context.RequestTypes.FindAsync(id);
            if (type != null)
            {
                _context.RequestTypes.Remove(type);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<RequestType>> GetAllAsync()
        {
            return await _context.RequestTypes.ToListAsync();
        }

        public async Task<RequestType> GetByIdAsync(long id)
        {
            return await _context.RequestTypes.FindAsync(id);
        }

        public async Task UpdateAsync(RequestType requestType)
        {
            _context.RequestTypes.Update(requestType);
            await _context.SaveChangesAsync();
        }
    }
}
