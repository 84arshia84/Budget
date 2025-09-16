using Application.Contracts;
using Application.Dto.AccessGroupe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.AccessGroupe
{
    public class AddAccessGroupDtoValidator
    {
        private readonly IRequestTypeService _requestTypeService;
        private readonly IRequestingDepartmenService _requestingDepartmenService;
        private readonly IFundingSourceService _fundingSourceService;

        public AddAccessGroupDtoValidator(
            IRequestTypeService requestTypeService,
            IRequestingDepartmenService requestingDepartmenService,
            IFundingSourceService fundingSourceService)
        {
            _requestTypeService = requestTypeService;
            _requestingDepartmenService = requestingDepartmenService;
            _fundingSourceService = fundingSourceService;
        }

        public async Task ValidateAsync(AddAccessGroupDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // بررسی RequestType ها
            foreach (var id in dto.AccessGroupRequestTypes ?? new List<long>())
            {
                var requestType = await _requestTypeService.GetByIdAsync(id);
                if (requestType == null)
                    throw new ArgumentException($"نوع درخواست با شناسه {id} یافت نشد.");
            }

            // بررسی RequestingDepartment ها
            foreach (var id in dto.AccessGroupRequestingDepartments ?? new List<long>())
            {
                var department = await _requestingDepartmenService.GetByIdAsync(id);
                if (department == null)
                    throw new ArgumentException($"دپارتمان با شناسه {id} یافت نشد.");
            }

            // بررسی FundingSource ها
            foreach (var id in dto.AccessGroupFundingSources ?? new List<long>())
            {
                var fundingSource = await _fundingSourceService.GetById(id);
                if (fundingSource == null)
                    throw new ArgumentException($"فاندینگ سورس با شناسه {id} یافت نشد.");
            }
        }
    }
}
