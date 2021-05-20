using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTDCore.Models;
using BTDCore.ViewModels;

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
