﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University_Manager.Models;

namespace University_Manager.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDbContext ctx;
        public StudentController()
        {
            ctx = new ApplicationDbContext();
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListStudent()
        {
            IEnumerable<StudentViewModel> models = ctx.Students.Select(m => new StudentViewModel()
            {
                Id = m.Id,
                Email = m.ApplicationUser.Email,
                PhoneNumber = m.ApplicationUser.PhoneNumber,
                Image = m.Image,
                GroupName = m.Group.Name
            }); ;
            return View(models);

        }

    }
}