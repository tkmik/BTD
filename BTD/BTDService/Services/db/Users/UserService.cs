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
            _dbContext.Users.Add(item);
            Save();
        }

        public async Task AddAsync(User item)
        {
            await _dbContext.Users.AddAsync(item);
            await SaveAsync();
        }

        public string Delete(int id)
        {
            var item = GetById(id);
            if (item is not null)
            {
                item.UserDetails.IsDeleted = true;
                _dbContext.Users.Update(item);
                //_dbContext.Entry(item).State = EntityState.Modified;
                Save();
                return "Card was deleted";
            }
            else
            {
                return "Card was not deleted";
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<ViewUserDetails>> GetAllUsersDetailsAsync(string search = default)
        {
            if (search is not null)
            {
                return await _dbContext.ViewUsersDetails.Where(
                    user => user.Login.Contains(search) 
                    || user.FirstName.Contains(search)
                    || user.LastName.Contains(search)).ToListAsync();
            }
            return await _dbContext.ViewUsersDetails.ToListAsync();

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
            return _dbContext.Users
                 .Include(table=>table.UserCapabilities)
                 .Include(table => table.UserDetails)
                 .FirstOrDefault(u => u.Login == login);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _dbContext.Users
                .Include(table => table.UserCapabilities)
                .Include(table=>table.UserDetails)
                .FirstOrDefaultAsync(u => u.Login == login);
        }

        public void Load()
        {
            _dbContext.Users.Load();
            _dbContext.UserProfiles.Load();
            _dbContext.UserCapabilities.Load();
        }

        public async Task LoadAsync()
        {
            await _dbContext.Users.LoadAsync();
            await _dbContext.UserProfiles.LoadAsync();
            await _dbContext.UserCapabilities.LoadAsync();
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
