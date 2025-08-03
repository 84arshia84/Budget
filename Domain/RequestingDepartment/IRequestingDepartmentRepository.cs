using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestingDepartment
{
    public interface IRequestingDepartmentRepository
    {
        Task<List<RequestingDepartment>> GetAllAsync();
        Task<RequestingDepartment> GetByIdAsync(long  id);
        Task AddAsync(RequestingDepartment requestingDepartment);
        Task UpdateAsync (RequestingDepartment requestingDepartment);
        Task DeleteAsync(long id);
    }
}
