using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager.Models;

namespace University_Manager.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your Home page.";

            return View();
        }

        

        public ActionResult About()
        {
            ViewBag.Message = "Your About page.";

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult AdminPage()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult ShowsRoles()
        {

            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return View(roles);

        }
    }
}