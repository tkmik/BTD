using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDCore.Models
{
    public class UserCapability
    {
        [Key]
        [Required]
        [ForeignKey("User")]
        public int Id { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool CanAddInfo { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool CanEditInfo { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool CanDeleteInfo { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool CanMakeReport { get; set; }
        public string IpAddress { get; set; }        
        [Required]
        [ConcurrencyCheck]
        public bool CanMakeNewUser { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool CanEditUser { get; set; }
        [Required]
        [ConcurrencyCheck]
        public bool CanDeleteUser { get; set; }
        [Required]
        [ConcurrencyCheck]
        public User User { get; set; }
    }
}
