using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Areas.Admin.Models
{
    public class ViewUser
    {
        public ViewUser()
        {
            Admin = Seller = User = false;
        }
        [Key]
        public string Id { get; set; }

        [Display(Name = "User")]
        public string UserName { get; set; }
        
        public bool Admin { get; set; }
        public bool Seller { get; set; }
        public bool User { get; set; }
    }
}