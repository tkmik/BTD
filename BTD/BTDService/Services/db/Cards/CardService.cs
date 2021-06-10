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

        public async Task<List<Documentation>> GetDocumentationByDesignationAsync(string searchWord)
        {
            return await _dbContext.AllDocumentations.Where(card => card.Designation.Contains(searchWord)).ToListAsync<Documentation>();
        }

        public async Task<List<Documentation>> GetDocumentationByNameAsync(string searchWord)
        {
            return await _dbContext.AllDocumentations.Where(card => card.Name.Contains(searchWord)).ToListAsync<Documentation>();
        }

        public async Task<List<Documentation>> GetAllDocumentationAsync(string searchWord = default)
        {
            if (searchWord is not null)
            {
                var documentation = (await GetDocumentationByNameAsync(searchWord))
                    .Union(await GetDocumentationByDesignationAsync(searchWord));
                if (documentation is not null)
                {
                    return documentation.ToList();
                }
            }
            return _dbContext.AllDocumentations.ToList<Documentation>();
        }

        public Card GetById(int id)
        {
            return _dbContext.Cards.FirstOrDefault(card => card.Id == id);
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _dbContext.Cards.FirstOrDefaultAsync(card => card.Id == id);
        }

        public async Task<List<Card>> GetCardByTypeAsync(int type)
        {
            return await _dbContext.Cards.Where(card => card.TypeId == type).ToListAsync();
        }

        public async Task<List<Documentation>> GetDesDocumentationAsync(string searchWord = default)
        {
            if (searchWord is not null)
            {
                var documentation = (await GetDocumentationByNameAsync(searchWord))
                    .Union(await GetDocumentationByDesignationAsync(searchWord))
                    .Where(card => card.TypeId == 1);
                if (documentation is not null)
                {
                    return documentation.ToList();
                }
            }
            return _dbContext.DesDocumentations.ToList<Documentation>();
        }

        public async Task<List<Documentation>> GetTechDocumentationAsync(string searchWord = default)
        {
            if (searchWord is not null)
            {
                var documentation = (await GetDocumentationByNameAsync(searchWord))
                    .Union(await GetDocumentationByDesignationAsync(searchWord))
                    .Where(card => card.TypeId == 2);
                if (documentation is not null)
                {
                    return documentation.ToList();
                }
            }
            return _dbContext.TechDocumentations.ToList<Documentation>();
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
                Save();
                return "Card has updated!";
            }
            else
            {
                return "Card have not found!";
            }
        }

        public async Task<string> UpdateAsync(Card item)
        {
            if (await GetByIdAsync(item.Id) is not null)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
                await SaveAsync();
                return "Card has updated!";
            }
            else
            {
                return "Card have not found!";
            }
        }

        public void Add(Card item)
        {
            if (item is not null)
            {
                _dbContext.Add(item);
                Save();
            }
        }

        public async Task AddAsync(Card item)
        {
            if (item is not null)
            {
                await _dbContext.AddAsync(item);
                await SaveAsync();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<string>> GetTypesOfDocumentationAsync()
        {
            return await _dbContext.TypesOfDocument.Select(item => item.Name).ToListAsync();
        }

        public async Task<string> GetTypeOfDocumentAsync(int number)
        {
            return (await _dbContext.TypesOfDocument.FirstOrDefaultAsync(type => type.Id == number)).Name;
        }

        public async Task<Card> GetCardByDesignationAsync(string designation)
        {
            return await _dbContext.Cards.FirstOrDefaultAsync(card => card.Designation == designation);
        }

        public string Delete(int id)
        {
            var item = GetById(id);
            if (item is not null)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                Save();
                return "Card was deleted";
            }
            else
            {
                return "Card was not deleted";
            }
            //_dbContext.Cards.Remove(GetById(id));

        }
    }
}
