using Microsoft.Extensions.Logging;
using Savi.Core.IServices;
using Savi.Data.Context;
using Savi.Data.Repositories.Interface;
namespace Savi.Core.Services
{
    public class FundingService : IFundingService
    {
        //private readonly IWalletRepository _walletRepository;
        //private readonly ISavingRepository _savingsGoalRepository;
        private readonly SaviDbContext _dbContext;
        private readonly ILogger<FundingService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public FundingService(SaviDbContext dbContext, ILogger<FundingService> logger, IUnitOfWork unitOfWork)
        {
           // _walletRepository = walletRepository;
            //_savingsGoalRepository = savingsGoalRepository;
            _dbContext = dbContext;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreditPersonalTarget(string walletId, string savingsGoalId, decimal amount)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (!await DebitWallet(walletId, amount))
                    {
                        _logger.LogWarning($"Failed to debit wallet {walletId} for amount: {amount}");
                        await transaction.RollbackAsync();
                        return false;
                    }

                    if (!await CreditSavingsGoal(savingsGoalId, amount))
                    {
                        _logger.LogWarning($"Failed to credit savings goal {savingsGoalId} for amount: {amount}");
                        await transaction.RollbackAsync();
                        return false;
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Error occurred during fund transfer: {ex}");
                    throw;
                }
            }
        }

        public async Task<bool> DebitWallet(string walletId, decimal amount)
        {
            try
            {
                var wallet = await _unitOfWork.WalletRepository.GetWalletByIdAsync(walletId);
                if (wallet == null || wallet.Balance < amount)
                {
                    return false;
                }
                wallet.Balance -= amount;
                _unitOfWork.WalletRepository.UpdateWalletAsync(wallet);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error debiting wallet {walletId}: {ex}");
                throw;
            }
        }

        public async Task<bool> CreditSavingsGoal(string savingsGoalId, decimal amount)
        {
            try
            {
                var savingsGoal = await _unitOfWork.SavingRepository.GetSavingByIdAsync(savingsGoalId);
                if (savingsGoal == null)
                {
                    return false;
                }

                savingsGoal.AmountSaved += amount;
                _unitOfWork.SavingRepository.UpdateSavingAsync(savingsGoal);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error crediting savings goal {savingsGoalId}: {ex}");
                throw;
            }
        }
        public async Task<bool> DebitPersonalTarget(string walletId, string savingsGoalId, decimal amount)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (!await DebitSavingsGoal(savingsGoalId, amount))
                    {
                        _logger.LogWarning($"Failed to debit savings goal {savingsGoalId} for amount: {amount}");
                        await transaction.RollbackAsync();
                        return false;
                    }

                    if (!await CreditWallet(walletId, amount))
                    {
                        _logger.LogWarning($"Failed to credit wallet {walletId} for amount: {amount}");
                        await transaction.RollbackAsync();
                        return false;
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError($"Error occurred during fund reverse transfer: {ex}");
                    throw;
                }
            }
        }

        public async Task<bool> DebitSavingsGoal(string savingsGoalId, decimal amount)
        {
            try
            {
                var savingsGoal = await _unitOfWork.SavingRepository.GetSavingByIdAsync(savingsGoalId);
                if (savingsGoal == null || savingsGoal.AmountSaved < amount)
                {
                    return false;
                }

                savingsGoal.AmountSaved -= amount;
                _unitOfWork.SavingRepository.UpdateSavingAsync(savingsGoal);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error debiting savings goal {savingsGoalId}: {ex}");
                throw;
            }
        }

        public async Task<bool> CreditWallet(string walletId, decimal amount)
        {
            try
            {
                var wallet = await _unitOfWork.WalletRepository.GetWalletByIdAsync(walletId);
                if (wallet == null)
                {
                    return false;
                }

                wallet.Balance += amount;
                _unitOfWork.WalletRepository.UpdateWalletAsync(wallet);
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error crediting wallet {walletId}: {ex}");
                throw;
            }
        }

    }

}
