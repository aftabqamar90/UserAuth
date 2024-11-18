using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAuth.Models.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public long Id { get; set; }
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }
    }
}
