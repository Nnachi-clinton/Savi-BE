using Savi.Model.Enums;

namespace Savi.Model.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsActive { get; set; }
        public decimal ContributionAmount { get; set; }  
        public bool IsOpen { get; set; }
        public DateTime CashoutDate { get; set; }
        public DateTime NextDueDate { get; set; }
        public int MaxNumberOfParticipants { get; set; }
        public FundFrequency Schedule { get; set; } 

        public ICollection<GroupTransaction> GroupTransactions { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
    }
}
