using BTDCore.Models;
using BTDCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTDService.Services.db.EventsLogs
{
    public interface IEventsLogService : IItemService<EventLog>
    {
        Task<List<ViewEventLog>> GetViewEventLogAsync(string searchWord = default);
    }
}
