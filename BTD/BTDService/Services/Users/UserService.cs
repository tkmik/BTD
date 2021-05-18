using BTDCore;
using BTDCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BTDService.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService()
        {
            _dbContext = new AppDbContext();
            
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }       

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public User GetUserByLogin(string login)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Login == login);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
        }

        public string UpdateUser(User user)
        {
            if (GetUserById(user.Id) is not null)
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                //_dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return "User has updated!";
            }
            else
            {
                return "User have not found!";
            }
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            if (await GetUserByIdAsync(user.Id) is not null)
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                //_dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return "User has updated!";
            }
            else
            {
                return "User have not found!";
            }
        }
    }
}
