using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goldenpineappleofthesun.MVC.Models
{
    public class RegistrationModel
    {
        [Display(Name = "Логин")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите имя")]
        public string Name { get; set; }
    }
}