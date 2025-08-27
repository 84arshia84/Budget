using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Allocation;

namespace Application.Validators.Allocation
{
    public class AllocationValidator
    {
        public void Validator(CreateAllocationDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
        }
        public void Validator(UpdateAllocationDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
        }
        public void Validator( List<ActionAllocationDto>  dtos)
        {
            foreach ( ActionAllocationDto dto in dtos)
            {
                  if (dto == null) throw new ArgumentException(nameof(dto));
                  if (dto.BudgetAmountPeriod == null || dto.BudgetAmountPeriod == 0 ) throw new ArgumentException("فیلد مبلغ نباید خالی باشد ");
            }

        }
    }
}
