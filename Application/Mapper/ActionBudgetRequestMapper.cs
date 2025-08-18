using Application.Dto.ActionBudgetRequest;
using Application.Dto.BudgetRequest;
using Domain.BudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ActionBudgetRequestEntity;
using System.Text.Json;

namespace Application.Mapper
{
    public class ActionBudgetRequestMapper
    {
        public List<ActionBudgetRequestEntity> ToEntity(List<ActionBudgetRequestDto> dtos)
        {
            return dtos.Select(dto => new ActionBudgetRequestEntity
            {
                Description = dto.Description,
                BudgetAmountPeriod = JsonSerializer.Serialize(dto.BudgetAmountPeriod)
            }).ToList();
        }
    }

}