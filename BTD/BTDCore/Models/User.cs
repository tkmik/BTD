using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace BTDCore.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MinLength(length: 6)]
        [Required]
        public string Login { get; set; }
        [MinLength(length: 6)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        [Required]
        public virtual UserProfile UserDetails { get; set; }
        [Required]
        public virtual UserCapability UserCapabilities { get; set; }
    }
}
