using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTDCore.Models;

namespace BTDService.Services.Users
{
    public interface IUserService
    {
        void Dispose();
        Task DisposeAsync();
        User GetUserById(int id);
        Task<User> GetUserByIdAsync(int id);
        User GetUserByLogin(string login);
        Task<User> GetUserByLoginAsync(string login);
        List<User> GetAllUsers();
        Task<List<User>> GetAllUsersAsync();
        string UpdateUser(User user);
        Task<string> UpdateUserAsync(User user);        
    }
}
