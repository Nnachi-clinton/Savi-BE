using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Interface
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        List<Wallet> GetWalletsAsync();
        void AddWalletAsync(Wallet wallet);
        void DeleteWalletAsync(Wallet wallet);
        void DeleteAllWalletAsync(List<Wallet> wallets);
        void UpdateWalletAsync(Wallet wallet);
        List<Wallet> FindWallets(Expression<Func<Wallet, bool>> expression);
        Wallet GetWalletByIdAsync(string id);
    }
}
