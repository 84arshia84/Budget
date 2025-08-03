using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.RequestingDepartmen;

namespace Application.Contracts
{
    public interface IRequestingDepartmenService
    {
        Task AddAsync(AddRequestingDepartmenDto dto);
        Task UpdateAsync (long id,UpdateRequestingDepartmenDto dto);
        Task<List<GetAllRequestingDepartmenDto>> GetAllAsync();
        Task<GetByIdRequestingDepartmenDto?> GetByIdAsync(long id);
        Task DeleteAsync(long id);


    }
}
