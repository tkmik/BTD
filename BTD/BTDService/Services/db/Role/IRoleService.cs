using BTDCore.Models;
using System.Collections.Generic;

namespace BTDService.Services.db.Role
{
    public interface IRoleService
    {
        UserCapability Create(User user, UserCapability capability);
        List<RoleEnum> Roles(string role = default);
    }
}
