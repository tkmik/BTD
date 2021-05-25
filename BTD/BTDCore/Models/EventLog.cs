using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDCore.Models
{
    public class EventLog
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Событие")]
        public int SystemEventId { get; set; }
        public virtual SystemEvent Event { get; set; }
        [Required]
        [Display(Name = "Пользователь")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        [Display(Name = "Дата события")]
        public DateTime DateOfEvent { get; set; }
    }
}
