using Goldenpineappleofthesun.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Goldenpineappleofthesun.MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (DBHelper.CheckUser(model.Login, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Не удалось войти :(");

            return View();
        }

        #endregion

        #region Registration

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (DBHelper.GetUserByLogin(model.Login) == null)
            {
                DBHelper.AddUser(model.Login, model.Password, model.Name, DBHelper.GetRoleByName("Standart"));
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Login", "Придумайте другое имя. Это уже занято");
            }

            return View();
        }

        #endregion

        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}