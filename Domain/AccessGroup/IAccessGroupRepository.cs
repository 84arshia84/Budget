using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AccessGroup
{
    public interface IAccessGroupRepository
    {
        Task AddAsync(AccessGroup entity);
        Task UpdateAsync(AccessGroup entity);
        Task DeleteAsync(long id);
        Task<AccessGroup> GetByIdAsync(long id);
        Task<List<AccessGroup>> GetAllAsync();
    }
}
