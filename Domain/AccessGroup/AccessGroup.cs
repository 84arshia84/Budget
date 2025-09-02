using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AccessGroup
{
    public class AccessGroup
    {
        public long Id { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }  

        public AccessGroupProperties Properties { get; set; }

        public ICollection<AccessGroupUser> Users { get; set; } = new List<AccessGroupUser>();
        public ICollection<AccessGroupRequestType> RequestTypes { get; set; } = new List<AccessGroupRequestType>();
        public ICollection<AccessGroupRequestingDepartment> RequestingDepartments { get; set; } = new List<AccessGroupRequestingDepartment>();
        public ICollection<AccessGroupFundingSource> FundingSources { get; set; } = new List<AccessGroupFundingSource>();
    }
}
