using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        List<T> GetAll();
        List<T> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAllAsync(List<T> entities);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();
        T GetById(string id);
    }
}
