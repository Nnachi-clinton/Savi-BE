using System.ComponentModel.DataAnnotations.Schema;

namespace Savi.Model.Entities
{
    public class Wallet : BaseEntity
    {
        public string WalletId { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string PaystackCustomerCode { get; set; } = string.Empty;

        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public string TransactionPin { get; set; } = string.Empty; 
        public ICollection<WalletFunding> WalletFundings { get; set; }

        public string SetWalletId(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+234"))
            {
                phoneNumber = phoneNumber.Substring(4);
                return phoneNumber;
            }
            else if (phoneNumber.StartsWith("0"))
            {
                phoneNumber = phoneNumber.Substring(1);
                return phoneNumber;
            }
            else if (phoneNumber.Length == 10 && long.TryParse(phoneNumber, out long walletId))
            {
                WalletId = walletId.ToString();
                return phoneNumber;
            }
            else
            {
                throw new Exception("Invalid Phone Number format");
            }
        }
    }
}
