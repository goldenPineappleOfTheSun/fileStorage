using Goldenpineappleofthesun.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goldenpineappleofthesun.MVC.Models
{
    public class UserItem
    {
        [Display(Name = "Имя")]
        public virtual string Name { get; set; }

        [Display(Name = "Логин")]
        public virtual string Login { get; set; }

        [Display(Name = "Роль")]
        public virtual RoleItem Role { get; set; }
    }
}