using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface ISavingRepository : IGenericRepository<Saving>
    {
        List<Saving> GetSavingsAsync();
        void AddSavingAsync(Saving saving);
        void DeleteSavingAsync(Saving saving);
        void DeleteAllSavingAsync(List<Saving> savings);
        void UpdateSavingAsync(Saving saving);
        List<Saving> FindSavings(Expression<Func<Saving, bool>> expression);
        Saving GetSavingByIdAsync(string id);
    }
}
