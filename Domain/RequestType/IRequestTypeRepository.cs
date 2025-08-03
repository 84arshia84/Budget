using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestType
{
    public interface IRequestTypeRepository
    {
        Task AddAsync (RequestType requestType);
        Task UpdateAsync (RequestType requestType);
        Task DeleteAsync (long id);
        Task<List<RequestType>> GetAllAsync ();
        Task <RequestType> GetByIdAsync (long id);
    }
}
