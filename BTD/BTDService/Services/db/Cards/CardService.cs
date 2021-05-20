using BTDCore;
using BTDCore.Models;
using BTDCore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTDService.Services.db.Cards
{
    public class CardService : ICardService
    {
        private readonly AppDbContext _dbContext;
        public CardService()
        {
            _dbContext = new AppDbContext();
            Load();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public List<AllDocumentation> GetAllDocumnetation()
        {
            return _dbContext.AllDocumentations.ToList();
        }
        public async Task<List<AllDocumentation>> GetAllDocumnetationAsync()
        {
            return  await _dbContext.AllDocumentations.ToListAsync();
        }

        public Card GetById(int id)
        {
            return _dbContext.Cards.FirstOrDefault(card => card.Id == id);
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _dbContext.Cards.FirstOrDefaultAsync(card => card.Id == id);
        }

        public List<Card> GetCardByType(int type)
        {
            return _dbContext.Cards.Where(card => card.TypeId == type).ToList();
        }

        public async Task<List<Card>> GetCardByTypeAsync(int type)
        {
            return await _dbContext.Cards.Where(card => card.TypeId == type).ToListAsync();
        }

        public List<DesDocumentation> GetDesDocumnetation()
        {
            return _dbContext.DesDocumentations.ToList();
        }

        public List<TechDocumentation> GetTechDocumnetation()
        {
            return _dbContext.TechDocumentations.ToList();
        }

        public void Load()
        {
            _dbContext.Cards.Load();
        }

        public async Task LoadAsync()
        {
            await _dbContext.Cards.LoadAsync();
        }

        public string Update(Card item)
        {
            if (GetById(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                //_dbContext.Users.Update(user);
                _dbContext.SaveChanges();
                return "User has updated!";
            }
            else
            {
                return "User have not found!";
            }
        }

        public async Task<string> UpdateAsync(Card item)
        {
            if (await GetByIdAsync(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                //_dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return "User has updated!";
            }
            else
            {
                return "User have not found!";
            }
        }
    }
}
