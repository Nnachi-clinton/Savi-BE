using Savi.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Savi.Model.Entities
{
    public class WalletFunding : BaseEntity
    {
        public decimal FundAmount { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string Narration { get; set; } = string.Empty;
        public TransactionType TransactionType { get; set; }

        [ForeignKey("WalletId")]
        public string WalletId { get; set; }
    }
}
