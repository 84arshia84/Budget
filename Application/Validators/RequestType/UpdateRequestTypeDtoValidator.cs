using Application.Dto.RequestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.RequestType
{
    public class UpdateRequestTypeDtoValidator
    {
        public void Validate(AddRequestTypeDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentException("توضیحات نوع درخواست الزامی است.");
        }
    }
}
