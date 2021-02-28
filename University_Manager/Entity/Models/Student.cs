﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using University_Manager.Models;

namespace University_Manager.Entity.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public virtual Group Group { get; set; }
        public int? GroupId { get; set; }

        public string AplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}