using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AccessGroup
{
    public class AccessGroupUser
    {
        public long Id { get; set; }

        public Guid UserId { get; set; }
        public long AccessGroupId { get; set; }

        public AccessGroup AccessGroup { get; set; }
    }
}
