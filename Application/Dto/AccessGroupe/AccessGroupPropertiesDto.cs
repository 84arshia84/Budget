using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccessGroupe
{
    public class AccessGroupPropertiesDto
    {
        public bool RequestTypeView { get; set; }
        public bool RequestTypeCreate { get; set; }
        public bool RequestTypeEdit { get; set; }
        public bool RequestTypeDelete { get; set; }

        public bool RequestingDepartmentView { get; set; }
        public bool RequestingDepartmentCreate { get; set; }
        public bool RequestingDepartmentEdit { get; set; }
        public bool RequestingDepartmentDelete { get; set; }

        public bool FundingSourceView { get; set; }
        public bool FundingSourceCreate { get; set; }
        public bool FundingSourceEdit { get; set; }
        public bool FundingSourceDelete { get; set; }
    }
}
