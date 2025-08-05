using Application.Dto.ActionBudgetRequest;
using Application.Dto.BudgetRequest;
using Domain.BudgetRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ActionBudgetRequestEntity;

namespace Application.Mapper
{
    public class ActionBudgetRequestMapper
    {
        public List<ActionBudgetRequestEntity>  DtoTomodelMapper(List<ActionBudgetRequestDto> dtos)
        {
            var entities = new List<ActionBudgetRequestEntity>();
            foreach (var dto  in dtos)
            {
                var entity = new ActionBudgetRequestEntity()
                {
                    Description = dto.Description,
                };
                entities.Add(entity);
            }


        }
    }
}
