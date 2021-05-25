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

        public List<Documentation> GetDocumentationByDesignation(string searchWord)
        {
            return _dbContext.AllDocumentations.Where(card => card.Designation.Contains(searchWord)).ToList<Documentation>();
        }

        public List<Documentation> GetDocumentationByName(string searchWord)
        {
            return _dbContext.AllDocumentations.Where(card => card.Name.Contains(searchWord)).ToList<Documentation>();
        }

        public List<Documentation> GetAllDocumentation(string searchWord = default)
        {
            if (searchWord is not null)
            {
                var documentation = GetDocumentationByName(searchWord)
                    .Union(GetDocumentationByDesignation(searchWord));
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

        public List<Card> GetCardByType(int type)
        {
            return _dbContext.Cards.Where(card => card.TypeId == type).ToList();
        }

        public List<Documentation> GetDesDocumentation(string searchWord = default)
        {
            if (searchWord is not null)
            {
                var documentation = GetDocumentationByName(searchWord)
                    .Union(GetDocumentationByDesignation(searchWord))
                    .Where(card => card.TypeId == 1);
                if (documentation is not null)
                {
                    return documentation.ToList();
                }
            }
            return _dbContext.DesDocumentations.ToList<Documentation>();
        }

        public List<Documentation> GetTechDocumentation(string searchWord = default)
        {
            if (searchWord is not null)
            {
                var documentation = GetDocumentationByName(searchWord)
                    .Union(GetDocumentationByDesignation(searchWord))
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
                //_dbContext.Users.Update(user);
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

        public List<string> GetTypesOfDocumentation()
        {
            return _dbContext.TypesOfDocument.Select(item => item.Name).ToList();
        }

        public string GetTypeOfDocument(int number)
        {
            return _dbContext.TypesOfDocument.FirstOrDefault(type => type.Id == number).Name;
        }

        public Card GetCardByDesignation(string designation)
        {
            return _dbContext.Cards.FirstOrDefault(card => card.Designation == designation);
        }

        public string Delete(int id)
        {
            var item = GetById(id);
            if (item is not null)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                //_dbContext.Users.Update(user);
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
