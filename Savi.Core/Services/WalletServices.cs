using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Savi.Core.IServices;
using Savi.Data.Repositories.Interface;
using Savi.Model;
using Savi.Model.Entities;
using Savi.Utility;

namespace Savi.Core.Services
{
    public class WalletServices : IWalletServices
    {
        private readonly ILogger _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;

        public WalletServices(ILogger<WalletServices> logger,  UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<string>> CreateWallet(string userId)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return new ApiResponse<string>(false, "User not found.", StatusCodes.Status400BadRequest, new List<string> { "User not found." });
                }
                var setWallet = new SetWalletAccountNumber();
                var wallet = new Wallet
                {
                    Id = Guid.NewGuid().ToString(),
                    WalletNumber = setWallet.SetWalletNumber(user.PhoneNumber),
                    Balance = 0,
                    AppUserId = user.Id,
                    TransactionPin = "1234"
                };
                await unitOfWork.WalletRepository.AddWalletAsync(wallet);
                unitOfWork.SaveChanges();
                return new ApiResponse<string>(true, "Wallet created successfully.", StatusCodes.Status201Created, new List<string> { "Wallet created successfully." });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a wallet. " + ex.InnerException);
                var errorList = new List<string> { ex.InnerException?.ToString() ?? ex.Message };
                return new ApiResponse<string>(false, "Error occurred while creating a wallet.", StatusCodes.Status500InternalServerError, errorList);
            }
        }
    }
}
