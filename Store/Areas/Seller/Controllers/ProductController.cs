using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IRepository;
using Microsoft.AspNet.Identity;
using PagedList;
using Store.Mappers;
using Store.Models;

namespace Store.Areas.Seller.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(
            IRepositoryProduct repository,
            IRepositoryCategory repositoryCategory,
            IMapper mapper
            )
        {
            Repository = repository;
            RepositoryCategory = repositoryCategory;
            Mapper = mapper;
        }

        IRepositoryCategory RepositoryCategory { get; set; }
        IRepositoryProduct Repository { get; set; }
        IMapper Mapper { get; set; }
        // GET: Seller/Product
        public ActionResult Index(int? page)
        {
            var pr = Repository.GetAll();
            if (pr != null)
            {
                var uName = User.Identity.GetUserName();
                var m = pr.Where(p=>p.UserSellerID==User.Identity.GetUserId()).Select(p =>
                {
                    var pv=(ViewProduct)Mapper.Map(p, typeof(Product), typeof(ViewProduct));
                    pv.UserSeller = uName;
                    pv.Category = Repository.GetCategoryByProduct(p.ProductId).ToList();
                    return pv;
                });
                int pageSize = 3;
                int pageNumber = (page ?? 1);
                return View(m.ToPagedList(pageNumber,pageSize));
            }
            return View((new List<ViewProduct>()).ToPagedList(1, 3));
        }

        // GET: Seller/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Seller/Product/Create
        public ActionResult Create()
        {
            ViewBag.Flag = false;
            var cat = RepositoryCategory.GetAll();
            var dlist = cat.Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.CategoryId.ToString()
            }).ToList();
            ViewBag.DropCategory = dlist;
            return View();
        }

        // GET: Seller/Product/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Flag = true;
            ViewBag.DropCategory = RepositoryCategory.GetAll().Select(p => new SelectListItem()
            {
                Text = p.Name,
                Value = p.CategoryId.ToString()
            }).ToList();
            var m = (ViewProduct)Mapper.Map(Repository.GetById(id), typeof(Product), typeof(ViewProduct));
            m.UserSeller = User.Identity.GetUserName();
            m.Category = Repository.GetCategoryByProduct(id).ToList();
            
            return View("Create", m);
        }
        // POST: Seller/Product/Create
        [HttpPost]
        public ActionResult Create(ViewProduct collection)
        {
            try
            {
                var p = (Product)Mapper.Map(collection, typeof(ViewProduct), typeof(Product));
                p.UserSellerID = User.Identity.GetUserId();
                var fl=Repository.Save(p);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        

        // GET: Seller/Product/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var m = (ViewProduct)Mapper.Map(Repository.GetById(id), typeof(Product), typeof(ViewProduct));
            m.Category = Repository.GetCategoryByProduct(id).ToList();
            return View(m);
        }

        // POST: Seller/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Repository.Delete(id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
