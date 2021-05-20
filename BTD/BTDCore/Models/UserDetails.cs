using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTDCore.Models
{
    public class UserProfile
    {
        [Key]
        [Required]
        [ForeignKey("User")]
        public int Id { get; set; }
        [MinLength(length: 2)]
        [Required]
        public string FirstName { get; set; }
        [MinLength(length: 2)]
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(10), MinLength(10)]
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
