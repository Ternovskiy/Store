using System.Web.Mvc;
using DataModul.DomainModel;
using DataModul.IRepository;

namespace Store.Areas.Seller.Controllers
{
    [Authorize(Roles = "seller")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}