using BTDCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDService.Services.db.Tables
{
    public class TableService : ITableService
    {
        private readonly AppDbContext _dbContext;
        public TableService()
        {
            _dbContext = new AppDbContext();
            Load();
        }

        public async Task<int> GetTableByIdAsync(int id)
        {
            return (await _dbContext.Tables.FirstOrDefaultAsync(table => table.Id == id)).Id;
        }

        public void Load()
        {
            _dbContext.Tables.Load();
        }
    }
}
