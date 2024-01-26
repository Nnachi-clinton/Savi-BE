using Microsoft.EntityFrameworkCore;
using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
using Savi.Model.Entities;
using System.Linq.Expressions;

namespace Savi.Data.Repositories.Implementation
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly SaviDbContext context;

        public WalletRepository(SaviDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddWalletAsync(Wallet wallet)
        {
            await AddAsync(wallet);
        }

        public async Task DeleteAllWalletAsync(List<Wallet> wallets)
        {
            await DeleteAllAsync(wallets);
        }

        public async Task DeleteWalletAsync(Wallet wallet)
        {
           await DeleteAsync(wallet);
        }

        public List<Wallet> FindWallets(Expression<Func<Wallet, bool>> expression)
        {
            return FindAsync(expression);
        }
        public async Task<Wallet> GetWalletByIdAsync(string id)
        {
            return await GetByIdAsync(id);
        }

        public List<Wallet> GetWalletsAsync()
        {
            return GetAll();
        }

        public void UpdateWalletAsync(Wallet wallet)
        {
            UpdateAsync(wallet);
        }
        public Wallet WalletById(string userId)
        {
            return context.Wallets.FirstOrDefault(w => w.AppUserId == userId);
        }
    }
}
