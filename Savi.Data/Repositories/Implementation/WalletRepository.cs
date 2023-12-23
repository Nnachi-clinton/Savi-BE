using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddWalletAsync(Wallet wallet)
        {
            AddAsync(wallet);
        }

        public void DeleteAllWalletAsync(List<Wallet> wallets)
        {
            DeleteAllAsync(wallets);
        }

        public void DeleteWalletAsync(Wallet wallet)
        {
            DeleteAsync(wallet);
        }

        public List<Wallet> FindWallets(Expression<Func<Wallet, bool>> expression)
        {
            return FindAsync(expression);
        }

        public Wallet GetWalletByIdAsync(string id)
        {
            return  GetByIdAsync(id);
        }

        public List<Wallet> GetWalletsAsync()
        {
            return GetAll();
        }

        public void UpdateWalletAsync(Wallet wallet)
        {
            UpdateAsync(wallet);
        }
    }
}
