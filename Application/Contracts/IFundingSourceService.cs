using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.FundingSource;
using Domain.FundingSource;

namespace Application.Contracts
{
    public interface IFundingSourceService
    {
        Task AddAsyinc(AddFundingSourceDto dto);
        Task UpdateAsync(long id ,UpdateFundingSourceDto dto);
        Task DeleteAsync(long id);
        Task<GetByIdFundingSourceDto>GetById(long  id);
        Task<List<GetAllFundingSourceDto>> GetAllAsync();
    }
}
