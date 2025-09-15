using Application.Contracts;
using Application.Dto.AccessGroupe;
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
                    FundingSourceDelete = dto.AccessGroupProperties.FundingSourceDelete
                },
                Users = dto.AccessGroupUsers.Select(u => new AccessGroupUser { UserId = u }).ToList(),
                RequestTypes = dto.AccessGroupRequestTypes.Select(r => new AccessGroupRequestType { RequestTypeId = r }).ToList(),
                RequestingDepartments = dto.AccessGroupRequestingDepartments.Select(d => new AccessGroupRequestingDepartment { RequestingDepartmentId = d }).ToList(),
                FundingSources = dto.AccessGroupFundingSources.Select(f => new AccessGroupFundingSource { FundingSourceId = f }).ToList(),
                DepartmentAccessgroupSystemParts = dto.AccessGroupSystemParts?.Select(s => new DepartmentAccessgroupSystemParts
                {
                    SystemParts = (SystemParts)s.SystemPart, // تبدیل int به Enum
                    AccessGroupEnum = (AccessGroupEnum)s.DepartmentAction // تبدیل int به Enum
                }).ToList() ?? new List<DepartmentAccessgroupSystemParts>()
        };

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
            return entities.Select(e => new GetAllAccessGroupDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description
            }).ToList();
        }

        public async Task<GetByIdAccessGroupDto> GetByIdAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            return new GetByIdAccessGroupDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                AccessGroupUsers = entity.Users.Select(u => u.UserId).ToList(),
                AccessGroupRequestTypes = entity.RequestTypes.Select(r => r.RequestTypeId).ToList(),
                AccessGroupRequestingDepartments = entity.RequestingDepartments.Select(d => d.RequestingDepartmentId).ToList(),
                AccessGroupFundingSources = entity.FundingSources.Select(f => f.FundingSourceId).ToList(),
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
                    FundingSourceDelete = entity.Properties.FundingSourceDelete
                },
                AccessGroupSystemParts = entity.DepartmentAccessgroupSystemParts.Select(s => new AccessGroupSystemPartDto
                {
                    SystemPart = (int)s.SystemParts, 
                    DepartmentAction = (int)s.AccessGroupEnum 
                }).ToList()
            };
        }
    };
        }
    

