using System.Linq;
using System.Web.Mvc;
using DataModul.BaseRepository;
using DataModul.DomainModel;

namespace Store.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        
        public ActionResult Index()
        {
            return View();
        }
       
    }
}