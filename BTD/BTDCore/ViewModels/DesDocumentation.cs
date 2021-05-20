using System;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.ViewModels
{
    public class DesDocumentation
    {
        [Display(Name = "Обозначение")]
        public string Designation { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Дата регистр.")]
        public DateTime DateOfRegistration { get; set; }
        public int A0 { get; set; }
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        private int numberOfSheets;
        [Display(Name = "Кол. листов")]
        public int NumberOfSheets
        {
            get { return numberOfSheets; }
            private set { numberOfSheets = A0 + A1 + A2 + A3 + A4; }
        }
        [Display(Name = "Дата изм.")]
        public DateTime DateOfChanges { get; set; }
        [Display(Name = "Аннулирован?")]
        public bool IsCanceled { get; set; }
        [Display(Name = "Временный?")]
        public bool IsTemporary { get; set; }
        [Display(Name = "Заметка")]
        public string Note { get; set; }
    }
}
