using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.RequestType;

namespace Application.Contracts
{
    public interface IRequestTypeService
    {
        Task AddAsync(AddRequestTypeDto dto);
        Task UpdateAsync(long id, UpdateRequestTypeDto dto);
        Task<List<GetAllRequestTypeDto>> GetAllAsync();
        Task <GetByIdRequestTypeDto>GetByIdAsync(long id);
        Task DeleteAsync(long id);
    }
}
