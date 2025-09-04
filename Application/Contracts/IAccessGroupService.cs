using Application.Dto.AccessGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAccessGroupService
    {
        Task AddAsync(AddAccessGroupDto dto);
        Task UpdateAsync(long id, UpdateAccessGroupDto dto);
        Task DeleteAsync(long id);
        Task<GetAccessGroupDto> GetByIdAsync(long id);
        Task<List<GetAccessGroupDto>> GetAllAsync();
    }
}
