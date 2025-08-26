using Application.Dto.FundingSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.FundingSource
{
    public class UpdateFundingSourceDtoValidator
    {
        public void Validate(UpdateFundingSourceDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentException("توضیحات منبع مالی نمی‌تواند خالی باشد.");
        }
    }
}
