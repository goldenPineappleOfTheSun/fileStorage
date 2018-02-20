using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goldenpineappleofthesun.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Логин")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Неверный логин или пароль")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Неверный логин или пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}