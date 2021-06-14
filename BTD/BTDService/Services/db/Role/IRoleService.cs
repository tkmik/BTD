using BTDCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTDService.Services.db.Role
{
    public interface IRoleService
    {
        UserCapability Create(User user, UserCapability capability);
        List<RoleEnum> Roles(string role = default);
        int GetRoleIndex(string role);
    }
}
