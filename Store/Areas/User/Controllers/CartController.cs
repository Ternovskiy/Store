using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IRepository;
using Microsoft.AspNet.Identity;
using Store.Areas.User.Proxy;

namespace Store.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    public class CartController : Controller
    {
        public CartController(IRepository<Cart> repository)
        {
            Repository = repository;
            proxyCart=new ProxyCart(repository);
        }

        IRepository<Cart> Repository { get; set; }

        ProxyCart proxyCart { get; set; }
        // GET: User/Cart
        public ActionResult Index()
        {
            var m = proxyCart.GetViewCart(User.Identity.GetUserId());
            ViewBag.PriceSumm = m.Sum(p =>p.PriceAll);
            return View(m);
        }

        public ActionResult AddToCart(int id)
        {
            Repository.Save(
                new Cart()
                {
                    
                    Count = 1,
                    ProductId = id,
                    UserId = User.Identity.GetUserId()
                });

            return RedirectToAction("Index");
        }

        public ActionResult UpCount(int id)
        {
            proxyCart.UpCountCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult DownCount(int id)
        {
            proxyCart.DownCountCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCart(int id)
        {
            Repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}