using BTDCore;
using System.Threading.Tasks;

namespace BTDService.Services
{
    public interface IItemService<T>
    {
        void Dispose();
        Task DisposeAsync();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Add(T item);
        Task AddAsync(T item);
        string Update(T item);
        Task<string> UpdateAsync(T item);
        string Delete(int id);
        void Load();
        Task LoadAsync();
        void Save();
        Task SaveAsync();
    }
}
