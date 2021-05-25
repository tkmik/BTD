using BTDCore.Models;
using BTDCore.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTDService.Services.db.Cards
{
    public interface ICardService : IItemService<Card>
    {
        List<Card> GetCardByType(int type);
        List<Documentation> GetAllDocumentation(string searchWord = default);
        List<Documentation> GetTechDocumentation(string searchWord = default);
        List<Documentation> GetDesDocumentation(string searchWord = default);
        List<Documentation> GetDocumentationByDesignation(string searchWord);
        List<Documentation> GetDocumentationByName(string searchWord);
        List<string> GetTypesOfDocumentation();
        string GetTypeOfDocument(int number);
        Card GetCardByDesignation(string designation);
    }
}
