using Savi.Core.DTO;
using Savi.Model;

namespace Savi.Core.IServices
{
    public interface IWalletServices
    {
        Task<ApiResponse<string>> CreateWallet(string userId);
       ResponseDto<WalletDto> GetUserWalletAsync(string userId);
        Task<string> VerifyTransaction(string referenceCode, string userId);
    }
}
