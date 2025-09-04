using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccessGroup
{
    public class AddAccessGroupDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<long> AccessGroupRequestTypes { get; set; } = new();
        public List<long> AccessGroupRequestingDepartments { get; set; } = new();
        public List<long> AccessGroupFundingSources { get; set; } = new();
        public List<Guid> AccessGroupUsers { get; set; } = new();
        public AccessGroupPropertiesDto AccessGroupProperties { get; set; }
    }
}
