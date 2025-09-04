using Application.Contracts;
using Application.Dto.AccessGroup;
using Domain.AccessGroup;
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

        public AccessGroupService(IAccessGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(AddAccessGroupDto dto)
        {
            var entity = new AccessGroup
            {
                Title = dto.Title,
                Description = dto.Description,
                Properties = new AccessGroupProperties
                {
                    RequestTypeView = dto.AccessGroupProperties.RequestTypeView,
                    RequestTypeCreate = dto.AccessGroupProperties.RequestTypeCreate,
                    RequestTypeEdit = dto.AccessGroupProperties.RequestTypeEdit,
                    RequestTypeDelete = dto.AccessGroupProperties.RequestTypeDelete,
                    RequestingDepartmentView = dto.AccessGroupProperties.RequestingDepartmentView,
                    RequestingDepartmentCreate = dto.AccessGroupProperties.RequestingDepartmentCreate,
                    RequestingDepartmentEdit = dto.AccessGroupProperties.RequestingDepartmentEdit,
                    RequestingDepartmentDelete = dto.AccessGroupProperties.RequestingDepartmentDelete,
                    FundingSourceView = dto.AccessGroupProperties.FundingSourceView,
                    FundingSourceCreate = dto.AccessGroupProperties.FundingSourceCreate,
                    FundingSourceEdit = dto.AccessGroupProperties.FundingSourceEdit,
                    FundingSourceDelete = dto.AccessGroupProperties.FundingSourceDelete,
                },
                Users = dto.AccessGroupUsers.Select(u => new AccessGroupUser { UserId = u }).ToList(),
                RequestTypes = dto.AccessGroupRequestTypes.Select(rt => new AccessGroupRequestType { RequestTypeId = rt }).ToList(),
                RequestingDepartments = dto.AccessGroupRequestingDepartments.Select(rd => new AccessGroupRequestingDepartment { RequestingDepartmentId = rd }).ToList(),
                FundingSources = dto.AccessGroupFundingSources.Select(fs => new AccessGroupFundingSource { FundingSourceId = fs }).ToList()
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(long id, UpdateAccessGroupDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException($"AccessGroup {id} not found");

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Properties = new AccessGroupProperties
            {
                RequestTypeView = dto.AccessGroupProperties.RequestTypeView,
                RequestTypeCreate = dto.AccessGroupProperties.RequestTypeCreate,
                RequestTypeEdit = dto.AccessGroupProperties.RequestTypeEdit,
                RequestTypeDelete = dto.AccessGroupProperties.RequestTypeDelete,
                RequestingDepartmentView = dto.AccessGroupProperties.RequestingDepartmentView,
                RequestingDepartmentCreate = dto.AccessGroupProperties.RequestingDepartmentCreate,
                RequestingDepartmentEdit = dto.AccessGroupProperties.RequestingDepartmentEdit,
                RequestingDepartmentDelete = dto.AccessGroupProperties.RequestingDepartmentDelete,
                FundingSourceView = dto.AccessGroupProperties.FundingSourceView,
                FundingSourceCreate = dto.AccessGroupProperties.FundingSourceCreate,
                FundingSourceEdit = dto.AccessGroupProperties.FundingSourceEdit,
                FundingSourceDelete = dto.AccessGroupProperties.FundingSourceDelete,
            };

            entity.Users = dto.AccessGroupUsers.Select(u => new AccessGroupUser { UserId = u, AccessGroupId = id }).ToList();
            entity.RequestTypes = dto.AccessGroupRequestTypes.Select(rt => new AccessGroupRequestType { RequestTypeId = rt, AccessGroupId = id }).ToList();
            entity.RequestingDepartments = dto.AccessGroupRequestingDepartments.Select(rd => new AccessGroupRequestingDepartment { RequestingDepartmentId = rd, AccessGroupId = id }).ToList();
            entity.FundingSources = dto.AccessGroupFundingSources.Select(fs => new AccessGroupFundingSource { FundingSourceId = fs, AccessGroupId = id }).ToList();

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(long id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<GetAccessGroupDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetAccessGroupDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                AccessGroupProperties = new AccessGroupPropertiesDto
                {
                    RequestTypeView = entity.Properties.RequestTypeView,
                    RequestTypeCreate = entity.Properties.RequestTypeCreate,
                    RequestTypeEdit = entity.Properties.RequestTypeEdit,
                    RequestTypeDelete = entity.Properties.RequestTypeDelete,
                    RequestingDepartmentView = entity.Properties.RequestingDepartmentView,
                    RequestingDepartmentCreate = entity.Properties.RequestingDepartmentCreate,
                    RequestingDepartmentEdit = entity.Properties.RequestingDepartmentEdit,
                    RequestingDepartmentDelete = entity.Properties.RequestingDepartmentDelete,
                    FundingSourceView = entity.Properties.FundingSourceView,
                    FundingSourceCreate = entity.Properties.FundingSourceCreate,
                    FundingSourceEdit = entity.Properties.FundingSourceEdit,
                    FundingSourceDelete = entity.Properties.FundingSourceDelete,
                },
                AccessGroupUsers = entity.Users.Select(u => u.UserId).ToList(),
                AccessGroupRequestTypes = entity.RequestTypes.Select(rt => rt.RequestTypeId).ToList(),
                AccessGroupRequestingDepartments = entity.RequestingDepartments.Select(rd => rd.RequestingDepartmentId).ToList(),
                AccessGroupFundingSources = entity.FundingSources.Select(fs => fs.FundingSourceId).ToList()
            };
        }

        public async Task<List<GetAccessGroupDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new GetAccessGroupDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                AccessGroupUsers = e.Users.Select(u => u.UserId).ToList(),
                AccessGroupRequestTypes = e.RequestTypes.Select(rt => rt.RequestTypeId).ToList(),
                AccessGroupRequestingDepartments = e.RequestingDepartments.Select(rd => rd.RequestingDepartmentId).ToList(),
                AccessGroupFundingSources = e.FundingSources.Select(fs => fs.FundingSourceId).ToList()
            }).ToList();
        }
    }
}
