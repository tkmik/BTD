using BTDCore.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.ViewModels
{
    public class ViewEventLog
    {
        [Display(Name = "Пользователь")]
        public string Login { get; set; }
        [Display(Name = "Имя таблицы")]
        public string NameCard { get; set; }
        [Display(Name = "Событие")]
        public string Event { get; set; }
        [Display(Name = "Дата события")]
        public DateTime DateOfEvent { get; set; }
    }
}
