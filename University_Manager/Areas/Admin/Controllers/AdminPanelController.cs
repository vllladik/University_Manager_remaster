using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager.Models;

namespace University_Manager.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: Admin/AdminPanel
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Dashboard()
        {
            




            return View();
        }

        public ActionResult Requests()
        {
            var reqests = _context.Requests.Select(x => new RequestViewModel
            {
                GroupName=x.GroupId,
                StudentName =x.StudentId

            }
            );




            return View(reqests);
        }

        public ActionResult GetStudent()
        {
            return View();
        }
    }
}