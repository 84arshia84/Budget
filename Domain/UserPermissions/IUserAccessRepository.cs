using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserPermissions
{
    public interface IUserAccessRepository
    {
        Task<UserPermissions> GetUserPermissionsAsync(Guid userId);
    }



}