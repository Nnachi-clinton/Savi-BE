using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class WalletFundingRepository : GenericRepository<WalletFunding>, IWalletFundingRepository
    {
        public WalletFundingRepository(SaviDbContext context) : base(context)
        {
        }

        public void AddWalletFundingAsync(WalletFunding walletFunding)
        {
            AddAsync(walletFunding);
        }

        public void DeleteAllWalletFundingAsync(List<WalletFunding> walletFundings)
        {
            DeleteAllAsync(walletFundings);
        }

        public void DeleteWalletFundingAsync(WalletFunding walletFunding)
        {
            DeleteAsync(walletFunding);
        }

        public List<WalletFunding> FindWalletFundings(Expression<Func<WalletFunding, bool>> expression)
        {
            return FindAsync(expression).ToList();
        }

        public WalletFunding GetWalletFundingByIdAsync(string id)
        {
            return GetByIdAsync(id);
        }

        public List<WalletFunding> GetWalletFundingsAsync()
        {
            return GetAll();
        }

        public void UpdateWalletFundingAsync(WalletFunding walletFunding)
        {
            UpdateAsync(walletFunding);
        }
    }
}
