using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager.Entity.Models;
using University_Manager.Models;

namespace University_Manager.Controllers
{
    public class GroupController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllGroups()
        {
            var groups = _context.Groups.Select(x => new GroupViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Students = x.Students.Select(y => new StudentViewModel
                {
                    Id = y.Id,
                    Email = y.ApplicationUser.Email,
                    PhoneNumber = y.ApplicationUser.PhoneNumber,
                    Image = y.Image,
                    GroupName = y.Group.Name
                }).ToList()
            });
            return View(groups);
        }

        public ActionResult SendRequest(string groupName)
        {
            var user = _context.Users.Find(User.Identity.GetUserId());
            if (user.Student.Group == null)
            {
                user.Student.Group = _context.Groups.FirstOrDefault(x => x.Name == groupName);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddGroup()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddGroup(GroupViewModel model)
        {
            if (model != null)
            {
                Group group = new Group()
                {
                    Name = model.Name
                };
                _context.Groups.Add(group);
                _context.SaveChanges();
            }
            return RedirectToAction("GetAllGroups");
        }


    }
}