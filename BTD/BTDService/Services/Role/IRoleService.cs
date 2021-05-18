using BTDCore.Models;

namespace BTDService.Services.Role
{
    public interface IRoleService
    {
        UserCapability Create(User user, UserCapability capability);
    }
}
