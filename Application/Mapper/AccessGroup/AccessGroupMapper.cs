using Application.Dto.AccessGroupe;
using Domain.AccessGroup;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper.AccessGroup
{
   
        public static class AccessGroupMapper
        {
            public static Domain.AccessGroup.AccessGroup ToEntity(AddAccessGroupDto dto)
            {
                return new Domain.AccessGroup.AccessGroup
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
                        SystemParts = (SystemParts)s.SystemPart,
                        AccessGroupEnum = (AccessGroupEnum)s.DepartmentAction
                    }).ToList() ?? new List<DepartmentAccessgroupSystemParts>()
                };
            }

            public static void UpdateEntity(Domain.AccessGroup.AccessGroup entity, AddAccessGroupDto dto)
            {
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
                    FundingSourceDelete = dto.AccessGroupProperties.FundingSourceDelete
                };

                entity.Users = dto.AccessGroupUsers
                    .Select(u => new AccessGroupUser { UserId = u, AccessGroupId = entity.Id })
                    .ToList();

                entity.RequestTypes = dto.AccessGroupRequestTypes
                    .Select(r => new AccessGroupRequestType { RequestTypeId = r, AccessGroupId = entity.Id })
                    .ToList();

                entity.RequestingDepartments = dto.AccessGroupRequestingDepartments
                    .Select(d => new AccessGroupRequestingDepartment { RequestingDepartmentId = d, AccessGroupId = entity.Id })
                    .ToList();

                entity.FundingSources = dto.AccessGroupFundingSources
                    .Select(f => new AccessGroupFundingSource { FundingSourceId = f, AccessGroupId = entity.Id })
                    .ToList();

                entity.DepartmentAccessgroupSystemParts = dto.AccessGroupSystemParts?.Select(s => new DepartmentAccessgroupSystemParts
                {
                    AccessGroupid = entity.Id,
                    SystemParts = (SystemParts)s.SystemPart,
                    AccessGroupEnum = (AccessGroupEnum)s.DepartmentAction
                }).ToList() ?? new List<DepartmentAccessgroupSystemParts>();
            }

            public static GetByIdAccessGroupDto ToGetByIdDto(Domain.AccessGroup.AccessGroup entity)
            {
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

            public static GetAllAccessGroupDto ToGetAllDto(Domain.AccessGroup.AccessGroup entity)
            {
                return new GetAllAccessGroupDto
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description
                };
            }
        }
    }