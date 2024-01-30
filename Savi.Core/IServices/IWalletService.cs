using Savi.Core.DTO;
using Savi.Model;
using Savi.Model.Entities;

namespace Savi.Core.IServices
{
	public  interface IWalletService
	{
		//Task<ApiResponse<bool>> CreateWallet(CreateWalletDto createWalletDto);
		Task<ApiResponse<List<WalletResponseDto>>> GetAllWallets();
		Task<ApiResponse<Wallet>> GetWalletByNumber(string phone);
		Task<ApiResponse<CreditResponseDto>> FundWallet(FundWalletDto fundWalletDto);
	}
}
