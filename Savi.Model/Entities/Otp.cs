using System.ComponentModel.DataAnnotations.Schema;

namespace Savi.Model.Entities
{
    public class Otp : BaseEntity
    {
        public long Value { get; set; }
        public bool IsUsed { get; set; }

        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
    }
}