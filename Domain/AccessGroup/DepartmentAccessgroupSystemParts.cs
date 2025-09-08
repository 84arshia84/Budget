using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.AccessGroup
{
    public class DepartmentAccessgroupSystemParts
    {
        public long Id { get; set; }
        public SystemParts SystemParts { get; set; }
        public AccessGroupEnum AccessGroupEnum { get; set; }
        public long AccessGroupid { get; set; }
       public AccessGroup AccessGroup { get; set; }
    }
}
