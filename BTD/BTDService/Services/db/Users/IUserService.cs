using BTDCore.Models;
using BTDCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTDService.Services.db.Users
{
    public interface IUserService : IItemService<User>
    {
        User GetUserByLogin(string login);
        List<User> GetAll();
        Task<List<User>> GetAllAsync();
        List<ViewUserDetails> GetAllUsersDetails();
        Task<User> GetUserByLoginAsync(string login);
    }
}
