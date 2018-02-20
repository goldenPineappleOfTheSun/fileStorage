using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Goldenpineappleofthesun.Web.Models;

namespace Goldenpineappleofthesun.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
    }
}