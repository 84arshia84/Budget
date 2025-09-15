using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AccessGroup
{
    public interface IAccessGroupRepository
    {
        Task AddAsync   (AccessGroup accessGroup);
        Task UpdateAsync (AccessGroup accessGroup);
        Task DeleteAsync(long id);

        Task<List<AccessGroup>> GetAllAsync();
        Task <AccessGroup>GetByIdAsync (long id);

    }
}
