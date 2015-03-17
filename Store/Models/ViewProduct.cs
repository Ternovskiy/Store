using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataModul.DomainModel;

namespace Store.Models
{
    public class ViewProduct
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        [Display(Name = "Category")]
        public List<Category> Category { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserSellerID { get; set; }
    
        [Display(Name = "Seller")]
        public string UserSeller { get; set; }
    }
}