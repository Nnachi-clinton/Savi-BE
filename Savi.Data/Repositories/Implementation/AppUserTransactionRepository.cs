using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class AppUserTransactionRepository : GenericRepository<AppUserTransaction>, IAppUserTransactionRepository
    {
        public AppUserTransactionRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddAppUserTransactionAsync(AppUserTransaction appUserTransaction)
        {
            AddAsync(appUserTransaction);
        }

        public void DeleteAllAppUserTransactionAsync(List<AppUserTransaction> appUserTransactions)
        {
           DeleteAllAsync(appUserTransactions);
        }

        public void DeleteAppUserTransactionAsync(AppUserTransaction appUserTransaction)
        {
            DeleteAsync(appUserTransaction);
        }

        public List<AppUserTransaction> FindAppUserTransactions(Expression<Func<AppUserTransaction, bool>> expression)
        {
            return FindAsync(expression);
        }

        public AppUserTransaction GetAppUserTransactionByIdAsync(string id)
        {
            return  GetByIdAsync(id);
        }

        public List<AppUserTransaction> GetAppUserTransactionsAsync()
        {
            return GetAll();
        }

        public void UpdateAppUserTransactionAsync(AppUserTransaction appUserTransaction)
        {
            UpdateAsync(appUserTransaction);
        }
    }
}
