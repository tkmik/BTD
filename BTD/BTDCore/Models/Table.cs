using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDCore.Models
{
    public enum TableName
    {
        Cards = 1,
        Notice,
        Users
    }

    public class Table
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя таблицы")]
        public string Name { get; set; }
    }
}
