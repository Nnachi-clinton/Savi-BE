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

        public void AddSavingAsync(Saving saving)
        {
            AddAsync(saving);
        }

        public void DeleteAllSavingAsync(List<Saving> savings)
        {
            DeleteAllAsync(savings);
        }

        public void DeleteSavingAsync(Saving saving)
        {
            DeleteAsync(saving);
        }

        public List<Saving> FindSavings(Expression<Func<Saving, bool>> expression)
        {
            return FindAsync(expression);
        }

        public Saving GetSavingByIdAsync(string id)
        {
            return GetByIdAsync(id);
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
