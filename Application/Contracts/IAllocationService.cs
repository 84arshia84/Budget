using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Allocation;
using Application.Dto.FundingSource;

namespace Application.Contracts
{
    public interface IAllocationService
    {
        Task AddAsync(CreateAllocationDto dto);
        Task UpdateAsync(long id, UpdateAllocationDto dto);
        Task DeleteAsync(long id);
        Task<GetAllocationDto> GetById(long id);
        Task<List<GetAllocationDto>> GetAllAsync();
    }
}
