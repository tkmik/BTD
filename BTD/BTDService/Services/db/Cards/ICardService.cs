using BTDCore.Models;
using BTDCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDService.Services.db.Cards
{
    public interface ICardService : IItemService<Card>
    {
        List<Card> GetCardByType(int type);
        List<AllDocumentation> GetAllDocumnetation();
        Task<List<AllDocumentation>> GetAllDocumnetationAsync();
        List<TechDocumentation> GetTechDocumnetation();
        List<DesDocumentation> GetDesDocumnetation();
        Task<List<Card>> GetCardByTypeAsync(int type);
    }
}
