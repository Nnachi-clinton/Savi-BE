using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IWalletFundingRepository : IGenericRepository<WalletFunding>
    {
        List<WalletFunding> GetWalletFundingsAsync();
        void AddWalletFundingAsync(WalletFunding walletFunding);
        void DeleteWalletFundingAsync(WalletFunding walletFunding);
        void DeleteAllWalletFundingAsync(List<WalletFunding> walletFundings);
        void UpdateWalletFundingAsync(WalletFunding walletFunding);
        List<WalletFunding> FindWalletFundings(Expression<Func<WalletFunding, bool>> expression);
        WalletFunding GetWalletFundingByIdAsync(string id);
    }
}
