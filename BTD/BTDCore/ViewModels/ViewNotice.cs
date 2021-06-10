using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDCore.ViewModels
{
    public class ViewNotice
    {
        [Display(Name = "Обозначение")]
        public string Designation { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Заметка")]
        public string Note { get; set; }
    }
}
