using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager.Entity.Models;
using University_Manager.Models;

namespace University_Manager.Areas.User.Controllers
{
    public class GroupController : Controller
    {
        // GET: User/Group   
        ApplicationDbContext _context = new ApplicationDbContext();
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
                Request rq = new Request()
                {
                    GroupId = _context.Groups.FirstOrDefault(x => x.Name == groupName).Id,
                    StudentId = _context.Users.Find(User.Identity.GetUserId()).Student.Id
                };

                _context.Requests.Add(rq);

                _context.SaveChanges();
            }
            return RedirectToAction("UsersView", "User");
        }
    }
}