using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDCore.Models
{
    public class Notice
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [ConcurrencyCheck]
        public string Designation { get; set; }
        [Required]
        [ConcurrencyCheck]
        public string Name { get; set; }
        [ConcurrencyCheck]
        public string Note { get; set; }
        [Required]
        [ConcurrencyCheck]
        public string Paths { get; set; }
    }
}
