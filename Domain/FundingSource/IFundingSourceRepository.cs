using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FundingSource
{
    public interface IFundingSourceRepository
    {
        Task AddAsync (FundingSource fundingSource);
        Task UpdateAsync (FundingSource fundingSource);
        Task DeleteAsync (long Id);
        Task <List<FundingSource>>GetAllAsync ();
        Task <FundingSource> GetById(long  id);
    }
}
