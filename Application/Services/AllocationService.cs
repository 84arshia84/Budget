
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.Allocation;
using Domain.Allocation;

namespace Application.Services
{
    public class AllocationService : IAllocationService
    {
        private readonly IAllocationRepository _repository;

        public AllocationService(IAllocationRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(CreateAllocationDto dto)
        {
            
        }

        public async Task DeleteAsync(long id)
        {

        }

        public async Task<List<GetAllocationDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllocationDto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(long id, UpdateAllocationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
