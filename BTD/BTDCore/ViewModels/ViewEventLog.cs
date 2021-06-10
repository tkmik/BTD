using BTDCore.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.ViewModels
{
    public class ViewEventLog
    {
        public int Id { get; set; }
        [Display(Name = "Пользователь")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Display(Name = "Имя таблицы")]
        public int? TableId { get; set; }
        public Table NameCard { get; set; }
        [Display(Name = "Событие")]
        public int SystemEventId { get; set; }
        public SystemEvent Event { get; set; }
        [Display(Name = "Дата события")]
        public DateTime DateOfEvent { get; set; }
    }
}
