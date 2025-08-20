
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.Allocation;
using Application.Mapper.Allocation;
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
            var allocation = AllocationMapper.ToEntity(dto);
            await _repository.AddAsync(allocation);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllocationDto>> GetAllAsync()
        {
            var allocations = await _repository.GetAllAsync();
            return AllocationMapper.ToDtoList(allocations);
        }

        public async Task<GetAllocationDto> GetById(long id)
        {
            var allocation = await _repository.GetByIdAsync(id);
            return allocation == null ? null : AllocationMapper.ToDto(allocation);
        }


        public async Task UpdateAsync(long id, UpdateAllocationDto dto)
        {
            try
            {
            var allocation = await _repository.GetByIdAsync(id);
            if (allocation == null) throw new Exception("Allocation not found!");

            AllocationMapper.UpdateEntity(allocation, dto);
            await _repository.UpdateAsync(allocation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
