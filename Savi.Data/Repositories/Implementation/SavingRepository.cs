using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class SavingRepository : GenericRepository<Saving>, ISavingRepository
    {
        public SavingRepository(SaviDbContext context) : base(context)
        {
        }

        public async Task AddSavingAsync(Saving saving)
        {
           await AddAsync(saving);
        }

        public async Task DeleteAllSavingAsync(List<Saving> savings)
        {
           await DeleteAllAsync(savings);
        }

        public async Task DeleteSavingAsync(Saving saving)
        {
            await DeleteAsync(saving);
        }

        public List<Saving> FindSavings(Expression<Func<Saving, bool>> expression)
        {
            return FindAsync(expression);
        }
        public async Task<Saving> GetSavingByIdAsync(string id)
        {
            return await GetByIdAsync(id);
        }

        public List<Saving> GetSavingsAsync()
        {
            return GetAll();
        }

        public void UpdateSavingAsync(Saving saving)
        {
            UpdateAsync(saving);
        }
    }
}
