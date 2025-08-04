using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.FundingSource;
using Domain.FundingSource;
using Domain.RequestingDepartment;

namespace Application.Services
{
    public class FundingSourceService : IFundingSourceService
    {
        private readonly IFundingSourceRepository _repository;

        public FundingSourceService(IFundingSourceRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsyinc(AddFundingSourceDto dto)
        {
            var entity = new FundingSource()
            {
                Description = dto.Description
            };
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllFundingSourceDto>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();
            return entity.Select(a=>new GetAllFundingSourceDto()
            {
                Id = a.Id,
                Description = a.Description

            }).ToList();
        }

        public async Task<GetByIdFundingSourceDto> GetById(long id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                return null;
            return new GetByIdFundingSourceDto

            {
                Id = entity.Id,
                Description = entity.Description
            };
        }

        public async Task UpdateAsync(long id , UpdateFundingSourceDto dto)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
                throw new KeyNotFoundException($"فاندینگ سورس با شناسه {id} یافت نشد.");
            entity.Description = dto.Description;
            await _repository.UpdateAsync(entity);
        }
    }
}
