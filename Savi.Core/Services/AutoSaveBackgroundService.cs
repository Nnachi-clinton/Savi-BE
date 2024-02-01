using Savi.Core.IServices;
using Savi.Data.Context;

namespace Savi.Core.Services
{
    public class AutoSaveBackgroundService : IAutoSaveBackgroundService
    {
        private readonly SaviDbContext _dbContext;
        private readonly IFundingService _fundingService;

        public AutoSaveBackgroundService(SaviDbContext dbContext, IFundingService fundingService)
        {
            _dbContext = dbContext;
            _fundingService = fundingService;
        }

        public async Task CheckAndExecuteAutoSaveTask()
        {
            var saving = _dbContext.Savings.FirstOrDefault() ?? throw new Exception("No saving record found");
            if (!saving.AutoSave)
            {
                return;
            }
            var wallet = _dbContext.Wallets.FirstOrDefault(w => w.AppUserId == saving.UserId) ?? throw new Exception("Wallet not found for the user");
            if (saving.AmountSaved >= saving.TargetAmount)
            {
                throw new Exception("Target already achieved");
            }
            DateTime nextRuntime = saving.NextRuntime.Date;
            DateTime currentUtcDate = DateTime.UtcNow.Date;

            int comparisonResult = nextRuntime.Date.CompareTo(currentUtcDate);

            if (comparisonResult != 0)
            {
                return;
            }           
            var savingGoalId = saving.Id;
            var amount = saving.AmountToAdd;
            var walletId = wallet.Id;
            var fundingServiceResult = await _fundingService.CreditPersonalTarget(walletId, savingGoalId, amount);
            if (!fundingServiceResult)
            {
                throw new Exception("Auto-funding was not successful");
            }
        }

    }
}
