using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savi.Model.Entities
{
    public class GroupSavingsMembers : BaseEntity
    {
        public string UserId { get; set; }
        public string GroupSavingId { get; set; }
        public bool IsGroupOwnder { get; set; }
        public int Position { get; set;}
        public DateTime LastSavingDate { get;}
        public bool IsPaid { get;}
    }
}
