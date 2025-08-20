using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Allocation;
using Domain.Allocation;
using Domain.AllocationActionBudgetRequest;


namespace Application.Mapper.Allocation
{
    public class AllocationMapper
    {
        public static Domain.Allocation.Allocation ToEntity(CreateAllocationDto dto)
        {   
            return new Domain.Allocation.Allocation
            {
                Title = dto.Title,
                Date = dto.Date,
                BudgetRequestId = dto.BudgetRequestId,
                AllocationActionBudgetRequests = dto.ActionAllocations
                    .Select(x => new AllocationActionBudgetRequest
                    {
                        ActionBudgetRequestEntityId = x.ActionBudgetRequestId,
                        AllocatedAmount = x.BudgetAmountPeriod
                    }).ToList()
            };
        }

        public static void UpdateEntity(Domain.Allocation.Allocation allocation, UpdateAllocationDto dto)
        {
            allocation.Title = dto.Title;
            allocation.Date = dto.Date;
            allocation.BudgetRequestId = dto.BudgetRequestId;

            allocation.AllocationActionBudgetRequests.Clear();
            allocation.AllocationActionBudgetRequests = dto.ActionAllocations
                .Select(x => new AllocationActionBudgetRequest
                {
                    AllocationId = allocation.Id,
                    ActionBudgetRequestEntityId = x.ActionBudgetRequestId,
                    AllocatedAmount = x.BudgetAmountPeriod
                }).ToList();
        }

        public static GetAllocationDto ToDto(Domain.Allocation.Allocation allocation)
        {
            return new GetAllocationDto
            {
                Title = allocation.Title,
                Date = allocation.Date,
                BudgetRequestId = allocation.BudgetRequestId,
                ActionAllocations = allocation.AllocationActionBudgetRequests
                    .Select(x => new ActionAllocationDto
                    {
                        ActionBudgetRequestId = x.ActionBudgetRequestEntityId,
                        BudgetAmountPeriod = x.AllocatedAmount
                    }).ToList()
            };
        }

        public static List<GetAllocationDto> ToDtoList(List<Domain.Allocation.Allocation> allocations)
        {
            return allocations.Select(ToDto).ToList();
        }
    }
}
