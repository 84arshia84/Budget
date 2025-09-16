using Application.Contracts;
using Application.Dto.AccessGroupe;
using Application.Mapper.AccessGroup;
using Application.Validators.AccessGroupe;
using Domain.AccessGroup;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccessGroupService : IAccessGroupService
    {
        private readonly IAccessGroupRepository _repository;
        private readonly AddAccessGroupDtoValidator _validator;

        public AccessGroupService(IAccessGroupRepository repository,
            AddAccessGroupDtoValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task AddAsync(AddAccessGroupDto dto)
        {
            await _validator.ValidateAsync(dto);

            var entity = AccessGroupMapper.ToEntity(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(long id, AddAccessGroupDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"AccessGroup با شناسه {id} پیدا نشد.");

            entity.Title = dto.Title;
            entity.Description = dto.Description;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<GetAllAccessGroupDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(AccessGroupMapper.ToGetAllDto).ToList();
        }

        public async Task<GetByIdAccessGroupDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return AccessGroupMapper.ToGetByIdDto(entity);
        }
    }
}
