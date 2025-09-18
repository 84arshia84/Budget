using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserPermissions
{
    public class UserPermissions
    {
        // --- RequestType ---
        public bool RequestTypeView { get; set; }
        public bool RequestTypeCreate { get; set; }
        public bool RequestTypeEdit { get; set; }
        public bool RequestTypeDelete { get; set; }

        // --- RequestingDepartment ---
        public bool RequestingDepartmentView { get; set; }
        public bool RequestingDepartmentCreate { get; set; }
        public bool RequestingDepartmentEdit { get; set; }
        public bool RequestingDepartmentDelete { get; set; }

        // --- FundingSource ---
        public bool FundingSourceView { get; set; }
        public bool FundingSourceCreate { get; set; }
        public bool FundingSourceEdit { get; set; }
        public bool FundingSourceDelete { get; set; }

        // --- BudgetRequest ---
        public bool BudgetRequestView { get; set; }
        public bool BudgetRequestCreate { get; set; }
        public bool BudgetRequestEdit { get; set; }
        public bool BudgetRequestDelete { get; set; }

        // --- Allocation ---
        public bool AllocationView { get; set; }
        public bool AllocationCreate { get; set; }
        public bool AllocationEdit { get; set; }
        public bool AllocationDelete { get; set; }

        // --- Payment ---
        public bool PaymentView { get; set; }
        public bool PaymentCreate { get; set; }
        public bool PaymentEdit { get; set; }
        public bool PaymentDelete { get; set; }

        // --- Allowed Entities ---
        public HashSet<long> AllowedRequestTypeIds { get; set; } = new();
        public HashSet<long> AllowedDepartmentIds { get; set; } = new();
        public HashSet<long> AllowedFundingSourceIds { get; set; } = new();
    }
}