using BTDCore.Models;

namespace BTDService.Services.db.Role
{
    public interface IRoleService
    {
        UserCapability Create(User user, UserCapability capability);
    }
}
