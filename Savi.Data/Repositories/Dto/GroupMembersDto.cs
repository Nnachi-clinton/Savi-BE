using Savi.Model.Entities;

namespace Savi.Data.Repository.DTO
{
    public class GroupMembersDto
    {
        public AppUser User { get; set; }
        public string UserId { get; set; }

        public string GroupSavingsId { get; set; }

        //public GroupSavingsRespnseDto GroupSavings { get; set; }

        public bool IsGroupOwner { get; set; }

        public int Positions { get; set; }

        public DateTime LastsavingsDate { get; set; }
    }
}
