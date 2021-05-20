using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDService.Services
{
    public interface IItemService<T>
    {
        void Dispose();
        Task DisposeAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        string Update(T item);
        Task<string> UpdateAsync(T item);
        void Load();
        Task LoadAsync();
    }
}
