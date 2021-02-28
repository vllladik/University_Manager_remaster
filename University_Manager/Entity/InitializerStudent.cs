using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using University_Manager.Models;

namespace University_Manager.Entity
{
    public class InitializerStudent : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {



    }
}