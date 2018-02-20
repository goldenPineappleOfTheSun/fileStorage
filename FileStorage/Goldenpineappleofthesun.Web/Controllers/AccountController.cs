using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Goldenpineappleofthesun.Web.Models;
using System.Web.Security;

namespace Goldenpineappleofthesun.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public object DBHelper { get; private set; }
        #region Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        #endregion

        #region Registration

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        #endregion

        public void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View();

            if (DBHelper.Users.GetByLogin(model.Login) == null)
            {
                DBHelper.Ad(model.Login, model.Password, model.Name, model.BirthDay);
                FormsAuthentication.SetAuthCookie(model.Login, true);
                return RedirectToAction("Index", "Calc");
            }
            else
            {
                ModelState.AddModelError("Login", "Придумайте другое имя. Это уже занято");
            }

            return View();
        }
    }
}