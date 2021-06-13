using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Role Role { get; set; }
        [Required]
        public UserProfile UserDetails { get; set; }
        [Required]
        public UserCapability UserCapabilities { get; set; }
        public ICollection<EventLog> Events { get; set; }
        public User()
        {
            UserDetails = new UserProfile();
            UserCapabilities = new UserCapability();
        }
    }
}
