using BTDCore.Models;
using BTDCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTDService.Services.db.Users
{
    public interface IUserService : IItemService<User>
    {
        Task<List<User>> GetAllAsync();
        Task<List<ViewUserDetails>> GetAllUsersDetailsAsync(string search = default);
        User GetUserByLogin(string login);
        Task<User> GetUserByLoginAsync(string login);
    }
}
