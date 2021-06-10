using System;
using System.ComponentModel.DataAnnotations;

namespace BTDCore.ViewModels
{
    public class ViewUserDetails
    {
        [Display(Name = "Логин")]
        public string Login { get; set; }
        [Display(Name = "Роль")]
        public string RoleName { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; }
        [Display(Name = "Удален?")]
        public bool IsDeleted { get; set; }
    }
}
