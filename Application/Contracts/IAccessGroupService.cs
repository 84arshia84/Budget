using Application.Dto.AccessGroupe;
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
        Task UpdateAsync(long id, AddAccessGroupDto dto);
        Task DeleteAsync(long id);
        Task<List<GetAllAccessGroupDto>> GetAllAsync();
        Task<GetByIdAccessGroupDto> GetByIdAsync(long id);
    }
}
