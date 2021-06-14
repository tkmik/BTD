using BTDCore;
using System.Linq;
using BTDCore.Models;
using BTDService.Services.db.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BTDService.Services.db.Role
{
    public class RoleService : IRoleService
    {
        IUserService _userService;
        private readonly AppDbContext _dbContext;
        public RoleService()
        {
            _dbContext = new AppDbContext();
            _userService = new UserService();
        }
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

        public int GetRoleIndex(string role)
        {
            return _dbContext.Roles.FirstOrDefault(r => r.Name.Equals(role)).Id;
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
