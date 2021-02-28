using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace University_Manager.Models.Roles
{
    public class AppDbInitializer
    { 
      
        public static void SeedUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            if (!roleManager.Roles.Any())
            {
  var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "User" };
                var role3 = new IdentityRole { Name = "Student" };

                // добавляем роли в бд
                roleManager.Create(role1);
            roleManager.Create(role2);
                roleManager.Create(role3);
            }

            if (!userManager.Users.Any())
            {
                var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "admin@gmail.com" };
            string password = "Qwerty1-";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, "Admin");
            }
            }
                // создаем пользователей
         

        }






    }
}