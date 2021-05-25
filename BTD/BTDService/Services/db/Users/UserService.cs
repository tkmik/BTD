using BTDCore;
using BTDCore.Models;
using BTDCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTDService.Services.db.Users
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService()
        {
            _dbContext = new AppDbContext();
            Load();
        }

        public void Add(User item)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(User item)
        {
            throw new System.NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public List<ViewUserDetails> GetAllUsersDetails()
        {
            return _dbContext.ViewUsersDetails.ToList();
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> GetByIdAsync(int id)
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

        public void Load()
        {
            _dbContext.Users.Load();
        }

        public async Task LoadAsync()
        {
            await _dbContext.Users.LoadAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public string Update(User item)
        {
            if (GetById(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                //_dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return "User has updated!";
            }
            else
            {
                return "User have not found!";
            }
        }

        public async Task<string> UpdateAsync(User item)
        {
            if (await GetByIdAsync(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
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
