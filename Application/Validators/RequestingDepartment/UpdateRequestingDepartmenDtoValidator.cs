using Application.Dto.RequestingDepartmen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.RequestingDepartment
{
    public class UpdateRequestingDepartmenDtoValidator
    {
        public void Validate(AddRequestingDepartmenDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentException("نام دپارتمان الزامی است.");
        }
    }
}
