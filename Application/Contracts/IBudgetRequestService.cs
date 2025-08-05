using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.BudgetRequest;

namespace Application.Contracts
{
    public interface IBudgetRequestService
    {
        Task AddAsyinc(AddBudgetRequestDto dto);
        Task UpdateAsyinc(UpdateBudgetRequestDto dto);
        Task DeleteAsyinc( long id );
        Task<ICollection<GetByIdBudgetRequestDto>> GetByIdAsync(long id);
        Task <List<ICollection<GetAllBudgetRequestDto>>> GetAllAsync();
         

    }
}
