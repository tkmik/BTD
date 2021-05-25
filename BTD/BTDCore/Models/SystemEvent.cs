using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.Models
{
    public class SystemEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Событие")]
        public string Name { get; set; }
        public virtual ICollection<EventLog> EventsLog { get; set; }
    }
}
