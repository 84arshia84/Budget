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
            var entities = new List<ActionBudgetRequestEntity>();

            foreach (var dto in dtos)
            {
                string budgetAmountPeriodJson = JsonSerializer.Serialize(dto.BudgetAmountPeriod);

                var entity = new ActionBudgetRequestEntity()
                {
                    Description = dto.Description,
                    BudgetAmountPeriod = budgetAmountPeriodJson
                };

                entities.Add(entity);
            }

            return entities;
        }
    }
}

