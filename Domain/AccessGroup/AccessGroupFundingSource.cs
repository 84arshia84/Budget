using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AccessGroup
{
    public class AccessGroupFundingSource
    {
        public long Id { get; set; }

        public long AccessGroupId { get; set; }
        public long FundingSourceId { get; set; }

        public AccessGroup AccessGroup { get; set; }
    }
}
