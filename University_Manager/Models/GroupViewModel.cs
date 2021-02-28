using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Manager.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<StudentViewModel> Students { get; set; }
    }
}