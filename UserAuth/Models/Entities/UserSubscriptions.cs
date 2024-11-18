using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuth.Models.Entities
{
    [Table("UserSubscriptions")]
    public class UserSubscriptions
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
    }
}