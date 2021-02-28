using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager.Models;

namespace University_Manager.Areas.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }

    }
}