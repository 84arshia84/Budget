using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.RequestingDepartment;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class RequestingDepartmentRepository : IRequestingDepartmentRepository
    {
        private readonly AppDbContext _context;

        public RequestingDepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RequestingDepartment requestingDepartment)
        {
            _context.RequestingDepartments.Add(requestingDepartment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RequestingDepartment>> GetAllAsync()
        {
            return await _context.RequestingDepartments.ToListAsync();
        }

        public async Task<RequestingDepartment> GetByIdAsync(long id)
        {
            return await _context.RequestingDepartments.FindAsync(id);
        }

        public async Task UpdateAsync(RequestingDepartment requestingDepartment)
        {
            _context.RequestingDepartments.Update(requestingDepartment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync( long id)
        {
            var Department = await _context.RequestingDepartments.FindAsync(id);
            if (Department != null)
            {
                _context.RequestingDepartments.Remove(Department);
                await _context.SaveChangesAsync();
            }
        }
    }
}
