using BTDCore.Models;
using BTDCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDService.Services.db.Notices
{
    public interface INoticeService : IItemService<Notice>
    {
        Task<List<ViewNotice>> GetNoticesAsync(string search = default);
        Task<Notice> GetNoticeByDesignationAsync(string designation);
    }
}
