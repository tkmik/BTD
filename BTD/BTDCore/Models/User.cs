using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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
        public Role Role { get; set; }
        [Required]
        public UserProfile UserDetails { get; set; }
        [Required]
        public UserCapability UserCapabilities { get; set; }
    }
}
