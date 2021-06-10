using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.Models
{
    public enum BTDSystemEvents
    {
        EnterIntoSystem = 1,
        ExitFromSystem,
        Adding,
        Editing,
        Deleting,
        MakingReport
    }

    public class SystemEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Событие")]
        public string Name { get; set; }
        public ICollection<EventLog> EventsLog { get; set; }
    }
}
