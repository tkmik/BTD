using BTDCore.Models;
using BTDCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTDService.Services.db.Cards
{
    public interface ICardService : IItemService<Card>
    {
        Task<List<Card>> GetCardByTypeAsync(int type);
        Task<List<Documentation>> GetAllDocumentationAsync(string searchWord = default);
        Task<List<Documentation>> GetTechDocumentationAsync(string searchWord = default);
        Task<List<Documentation>> GetDesDocumentationAsync(string searchWord = default);
        Task<List<Documentation>> GetDocumentationByDesignationAsync(string searchWord);
        Task<List<Documentation>> GetDocumentationByNameAsync(string searchWord);
        Task<List<string>> GetTypesOfDocumentationAsync();
        Task<string> GetTypeOfDocumentAsync(int number);
        Task<Card> GetCardByDesignationAsync(string designation);
    }
}
