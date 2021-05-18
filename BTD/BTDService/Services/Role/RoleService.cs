using BTDCore.Models;

namespace BTDService.Services.Role
{
    public class RoleService : IRoleService
    {
        public UserCapability Create(User user, UserCapability capability)
        {
            UserCapability capa = new UserCapability
            {
                IsEntered = false,
                CanAddInfo = capability.CanAddInfo,
                CanEditInfo = capability.CanEditInfo,
                CanDeleteInfo = capability.CanDeleteInfo,
                CanMakeReport = capability.CanMakeReport,
                IsDeleted = false,
                CanMakeNewUser = capability.CanMakeNewUser,
                CanEditUser = capability.CanEditUser,
                CanDeleteUser = capability.CanDeleteUser,
            };
            return capa;
        }
    }
}
