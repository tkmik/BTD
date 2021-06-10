using BTDCore.Models;
using BTDService.Services.db.Users;
using System.Collections.Generic;

namespace BTDService.Services.db.Role
{
    public class RoleService : IRoleService
    {
        IUserService _userService;
        public UserCapability Create(User user, UserCapability capability)
        {
            
            UserCapability capa = new UserCapability
            {
                CanAddInfo = capability.CanAddInfo,
                CanEditInfo = capability.CanEditInfo,
                CanDeleteInfo = capability.CanDeleteInfo,
                CanMakeReport = capability.CanMakeReport,
                CanMakeNewUser = capability.CanMakeNewUser,
                CanEditUser = capability.CanEditUser,
                CanDeleteUser = capability.CanDeleteUser,
            };
            return capa;
        }

        public List<RoleEnum> Roles(string role = default)
        {
            List<RoleEnum> list = new List<RoleEnum>();
            if (role is "Admin")
            {
                list.Add(RoleEnum.Admin);
                return list;
            }
            if (role is "User")
            {
                list.Add(RoleEnum.User);
                return list;
            }
            list.Add(RoleEnum.Admin);
            list.Add(RoleEnum.User);
            return list;
        }
    }
}
