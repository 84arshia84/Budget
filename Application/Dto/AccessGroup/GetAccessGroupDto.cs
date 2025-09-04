using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccessGroup
{
    public class GetAccessGroupDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AccessGroupPropertiesDto AccessGroupProperties { get; set; }
        public List<long> AccessGroupRequestTypes { get; set; }
        public List<long> AccessGroupRequestingDepartments { get; set; }
        public List<long> AccessGroupFundingSources { get; set; }
        public List<Guid> AccessGroupUsers { get; set; }
    }
}
