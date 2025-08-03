using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Dto.RequestType;
using Domain.RequestType;

namespace Application.Services
{
    public class RequestTypeService :IRequestTypeService
    {
        private readonly IRequestTypeRepository _repository;

        public RequestTypeService(IRequestTypeRepository repository)
        {
            _repository = repository;   
        }

        public async Task AddAsync(AddRequestTypeDto dto)
        {
            var entity = new RequestType
            {
                Description = dto.Description

            };
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllRequestTypeDto>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();
            return entity .Select(a=>new GetAllRequestTypeDto
            {
                Id =  a.Id,
                Description = a.Description
            }).ToList();
        }

        public async Task<GetByIdRequestTypeDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity ==null)
                return null;
            return new GetByIdRequestTypeDto

            {
                Id = entity.Id,
                Description = entity.Description
            };

        }

        public async Task UpdateAsync(long id, UpdateRequestTypeDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity ==null)
            throw new KeyNotFoundException($"ریکوست تایپ با شناسه {id} یافت نشد.");

            entity.Description = dto.Description;
            await _repository.UpdateAsync(entity);
        }
    }
}
