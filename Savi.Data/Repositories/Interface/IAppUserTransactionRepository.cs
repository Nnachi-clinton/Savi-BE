using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IAppUserTransactionRepository : IGenericRepository<AppUserTransaction>
    {
        List<AppUserTransaction> GetAppUserTransactionsAsync();
        void AddAppUserTransactionAsync(AppUserTransaction appUserTransaction);
        void DeleteAppUserTransactionAsync(AppUserTransaction appUserTransaction);
        void DeleteAllAppUserTransactionAsync(List<AppUserTransaction> appUserTransactions);
        void UpdateAppUserTransactionAsync(AppUserTransaction appUserTransaction);
        List<AppUserTransaction> FindAppUserTransactions(Expression<Func<AppUserTransaction, bool>> expression);
        AppUserTransaction GetAppUserTransactionByIdAsync(string id);
    }
}
