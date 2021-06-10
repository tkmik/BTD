using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.Models
{
    public enum RoleEnum
    {
        Admin = 1,
        User
    }
    public class Role
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
