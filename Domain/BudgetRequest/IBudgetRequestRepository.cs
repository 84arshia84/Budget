using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BudgetRequest
{
    public interface IBudgetRequestRepository
    {
        Task AddAsync (BudgetRequest  budgetRequest);
        Task UpdateAsync (BudgetRequest budgetRequest);
        Task DeleteAsync (string id);
        Task<List<BudgetRequest>> GetAllAsync();
        Task<BudgetRequest> GetById(long id);
    }
}
