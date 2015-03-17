using System.Web.Mvc;

namespace Store.Areas.User.Models
{
    public class ViewCart
    {

        public int Id { get; set; }
        public int Count { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        public bool Bought { get; set; } 


        public string NameProduct{ get; set; }
 
        [HiddenInput(DisplayValue = false)]
        public string Description{ get; set; }
        public string NameCategory{ get; set; }
        public string SellerName{ get; set; }
        public decimal Price{ get; set; }

        public decimal PriceAll { get { return Price*Count; } } 
    }
}