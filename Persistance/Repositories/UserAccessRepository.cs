using Domain.UserPermissions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserAccessRepository : IUserAccessRepository
    {
        private readonly AppDbContext _db;

        public UserAccessRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<UserPermissions> GetUserPermissionsAsync(Guid userId)
        {
            var groups = await _db.AccessGroups
                .Include(g => g.Users)
                .Include(g => g.RequestTypes)
                .Include(g => g.RequestingDepartments)
                .Include(g => g.FundingSources)
                .Include(g => g.Properties)
                .Where(g => g.Users.Any(u => u.UserId == userId))
                .ToListAsync();

            var perms = new UserPermissions();

            foreach (var g in groups)
            {
                if (g.Properties != null)
                {
                    // --- RequestType ---
                    perms.RequestTypeView |= g.Properties.RequestTypeView;
                    perms.RequestTypeCreate |= g.Properties.RequestTypeCreate;
                    perms.RequestTypeEdit |= g.Properties.RequestTypeEdit;
                    perms.RequestTypeDelete |= g.Properties.RequestTypeDelete;

                    // --- Department ---
                    perms.RequestingDepartmentView |= g.Properties.RequestingDepartmentView;
                    perms.RequestingDepartmentCreate |= g.Properties.RequestingDepartmentCreate;
                    perms.RequestingDepartmentEdit |= g.Properties.RequestingDepartmentEdit;
                    perms.RequestingDepartmentDelete |= g.Properties.RequestingDepartmentDelete;

                    // --- FundingSource ---
                    perms.FundingSourceView |= g.Properties.FundingSourceView;
                    perms.FundingSourceCreate |= g.Properties.FundingSourceCreate;
                    perms.FundingSourceEdit |= g.Properties.FundingSourceEdit;
                    perms.FundingSourceDelete |= g.Properties.FundingSourceDelete;

                    // --- BudgetRequest ---
                    perms.BudgetRequestView |= g.Properties.RequestTypeView;   // میشه جدا تعریف کنی
                    perms.BudgetRequestCreate |= g.Properties.RequestTypeCreate;
                    perms.BudgetRequestEdit |= g.Properties.RequestTypeEdit;
                    perms.BudgetRequestDelete |= g.Properties.RequestTypeDelete;

                    // --- Allocation ---
                    perms.AllocationView |= g.Properties.FundingSourceView;
                    perms.AllocationCreate |= g.Properties.FundingSourceCreate;
                    perms.AllocationEdit |= g.Properties.FundingSourceEdit;
                    perms.AllocationDelete |= g.Properties.FundingSourceDelete;

                    // --- Payment ---
                    perms.PaymentView |= g.Properties.FundingSourceView;
                    perms.PaymentCreate |= g.Properties.FundingSourceCreate;
                    perms.PaymentEdit |= g.Properties.FundingSourceEdit;
                    perms.PaymentDelete |= g.Properties.FundingSourceDelete;
                }

                foreach (var rt in g.RequestTypes)
                    perms.AllowedRequestTypeIds.Add(rt.RequestTypeId);

                foreach (var d in g.RequestingDepartments)
                    perms.AllowedDepartmentIds.Add(d.RequestingDepartmentId);

                foreach (var f in g.FundingSources)
                    perms.AllowedFundingSourceIds.Add(f.FundingSourceId);
            }

            return perms;
        }
    }
}