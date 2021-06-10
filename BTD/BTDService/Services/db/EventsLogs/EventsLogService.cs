using BTDCore;
using BTDCore.Models;
using BTDCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTDService.Services.db.EventsLogs
{
    public class EventsLogService : IEventsLogService
    {
        private readonly AppDbContext _dbContext;
        public EventsLogService()
        {
            _dbContext = new AppDbContext();
            Load();
        }
        public void Add(EventLog item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public async Task AddAsync(EventLog item)
        {
            await _dbContext.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public EventLog GetById(int id)
        {
            return _dbContext.EventsLog.FirstOrDefault(e => e.Id == id);
        }

        public async Task<EventLog> GetByIdAsync(int id)
        {
            return await _dbContext.EventsLog.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<ViewEventLog>> GetViewEventLogAsync(string searchWord)
        {
            if (searchWord is not null)
            {
                return await _dbContext.ViewEventsLog.Where(search => search.Event.Name.Contains(searchWord)).ToListAsync();
            }
            return await _dbContext.ViewEventsLog.ToListAsync();
        }

        public void Load()
        {
            _dbContext.EventsLog.Load();
        }

        public async Task LoadAsync()
        {
            await _dbContext.EventsLog.LoadAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public string Update(EventLog item)
        {
            if (GetById(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return "EventLog was updated!";
            }
            else
            {
                return "EventLog was not found!";
            }
        }

        public async Task<string> UpdateAsync(EventLog item)
        {

            if (GetById(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return "EventLog was updated!";
            }
            else
            {
                return "EventLog was not found!";
            }
        }
    }
}
