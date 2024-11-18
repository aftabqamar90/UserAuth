using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuth.Models.Entities
{
    [Table("Subscriptions")]
    public class Subscriptions
    {
        [Key]
        public long Id { get; set; }
        public required string Name { get; set; }
    }
}
