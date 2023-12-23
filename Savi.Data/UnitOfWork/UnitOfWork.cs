using Savi.Data.Context;
using Savi.Data.Repositories.Implementation;
using Savi.Data.Repositories.Interface;

namespace Savi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SaviDbContext _context;

        public UnitOfWork(SaviDbContext context)
        {
            _context = context;
            AppUserTransactionRepository = new AppUserTransactionRepository(_context);
            CardDetailsRepository = new CardDetailsRepository(_context);
            GroupRepository = new GroupRepository(_context);
            GroupTransactionRepository = new GroupTransactionRepository(_context);
            KycRepository = new KycRepository(_context);
            OtpRepository = new OtpRepository(_context);
            SavingRepository = new SavingRepository(_context);
            WalletFundingRepository = new WalletFundingRepository(_context);
            WalletRepository = new WalletRepository(_context);
        }

        public IAppUserTransactionRepository AppUserTransactionRepository { get; private set; }

        public ICardDetailsRepository CardDetailsRepository {get; private set;}

        public IGroupRepository GroupRepository {get; private set;}

        public IGroupTransactionRepository GroupTransactionRepository {get; private set;}

        public IKycRepository KycRepository {get; private set;}

        public IOtpRepository OtpRepository {get; private set;}

        public ISavingRepository SavingRepository {get; private set;}

        public IWalletFundingRepository WalletFundingRepository {get; private set;}

        public IWalletRepository WalletRepository {get; private set;}

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
