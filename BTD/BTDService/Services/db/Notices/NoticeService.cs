using BTDCore;
using BTDCore.Models;
using BTDCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTDService.Services.db.Notices
{
    public class NoticeService : INoticeService
    {
        private readonly AppDbContext _dbContext;
        public NoticeService()
        {
            _dbContext = new AppDbContext();
            Load();
        }

        public void Add(Notice item)
        {
            if (item is not null)
            {
                _dbContext.Add(item);
                Save();
            }
        }

        public async Task AddAsync(Notice item)
        {
            if (item is not null)
            {
                await _dbContext.AddAsync(item);
                await SaveAsync();
            }
        }

        public string Delete(int id)
        {
            var item = GetById(id);
            if (item is not null)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                Save();
                return "Notice was deleted";
            }
            else
            {
                return "Notice was not deleted";
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

        public Notice GetById(int id)
        {
            return _dbContext.Notices.FirstOrDefault(notice => notice.Id == id);
        }

        public async Task<Notice> GetByIdAsync(int id)
        {
            return await _dbContext.Notices.FirstOrDefaultAsync(notice => notice.Id == id);
        }

        public async Task<Notice> GetNoticeByDesignationAsync(string designation)
        {
            return await _dbContext.Notices.FirstOrDefaultAsync(notice => notice.Designation == designation);
        }

        public async Task<List<ViewNotice>> GetNoticesAsync(string search)
        {
            if (search is not null)
            {
                return await _dbContext.ViewNotices.Where(notice => notice.Name.Contains(search))
                    .Union(_dbContext.ViewNotices.Where(notice => notice.Designation.Contains(search)))
                    .ToListAsync();
            }
            return await _dbContext.ViewNotices.ToListAsync();
        }

        public void Load()
        {
            _dbContext.Notices.Load();
        }

        public async Task LoadAsync()
        {
            await _dbContext.Notices.LoadAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public string Update(Notice item)
        {
            if (GetById(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                Save();
                return "Notice has updated!";
            }
            else
            {
                return "Notice have not found!";
            }
        }

        public async Task<string> UpdateAsync(Notice item)
        {
            if (await GetByIdAsync(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                await SaveAsync();
                return "Notice has updated!";
            }
            else
            {
                return "Notice have not found!";
            }
        }
    }
}
