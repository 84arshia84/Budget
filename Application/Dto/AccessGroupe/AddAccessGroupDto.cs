using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccessGroupe
{
    public class AddAccessGroupDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<long> AccessGroupRequestTypes { get; set; }
        public List<long> AccessGroupRequestingDepartments { get; set; }
        public List<long> AccessGroupFundingSources { get; set; }
        public List<Guid> AccessGroupUsers { get; set; }

        public AccessGroupPropertiesDto AccessGroupProperties { get; set; }

        public List<AccessGroupSystemPartDto> AccessGroupSystemParts { get; set; }
    }
}
