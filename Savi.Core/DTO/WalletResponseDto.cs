using Savi.Model.Enums;

namespace Savi.Core.DTO
{
	public class WalletResponseDto
	{
		public string WalletNumber { get; set; } = string.Empty;
		public decimal Balance { get; set; }
		public Currency Currency { get; set; }
	}
}
