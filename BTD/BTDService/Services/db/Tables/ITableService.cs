using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDService.Services.db.Tables
{
    public interface ITableService
    {
        void Load();
        Task<int> GetTableByIdAsync(int id);
    }
}
