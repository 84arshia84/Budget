using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Allocation
{
    public interface IAllocationRepository
    {
        Task AddAsync (Allocation allocation);
        Task UpdateAsync (Allocation allocation);
        Task DeleteAsync (long Id);
        Task<List<Allocation>> GetAllAsync();
        Task <Allocation> GetByIdAsync(long Id);

        Task RemoveActionsByAllocationId(long allocationId);

    }
}
