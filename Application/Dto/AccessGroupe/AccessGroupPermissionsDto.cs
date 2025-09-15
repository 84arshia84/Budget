using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.AccessGroupe
{
    public class AccessGroupPermissionsDto
    {
        public bool Settings { get; set; }
        public bool AccessGroups { get; set; }
        public bool WorkFlow { get; set; }
        public bool Requests { get; set; }
        public bool Plannings { get; set; }
        public bool Allocations { get; set; }
        public bool Payments { get; set; }
        public bool Header { get; set; }
    }
}
