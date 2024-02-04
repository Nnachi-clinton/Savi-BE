namespace Savi.Model.Entities
{
    public class GroupSavingsMembers : BaseEntity
    {
        public string UserId { get; set; }

        public string GroupSavingsId { get; set; }

        public bool IsGroupOwner { get; set; }

        public int Positions { get; set; } = 1;

        public DateTime LastsavingDate { get; set; }
        public bool IsPaid { get; set; }

    }
}
