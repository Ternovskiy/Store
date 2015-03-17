using System.Web.Mvc;

namespace Store.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(name: "Admin_default",
                url: "Admin/{controller}/{action}/{id}"
                , defaults: new { action = "Index", controller = "Home", id = UrlParameter.Optional
                ,namespaces = new[] { "Store.Areas.Admin.Controllers" }
                }
            );
        }
    }
}