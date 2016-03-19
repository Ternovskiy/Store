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

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(
            IRepositoryProduct repository,
            IRepositoryCategory repositoryCategory,
            IRepositoryUser repositoryUser,
            IMapper mapper
            )
        {
            Repository = repository;
            RepositoryCategory = repositoryCategory;
            RepositoryUser = repositoryUser;
            Mapper = mapper;
        }

        IRepositoryProduct Repository { get; set; }
        IRepositoryCategory RepositoryCategory { get; set; }
        IRepositoryUser RepositoryUser { get; set; }
        IMapper Mapper { get; set; }
        // GET: Seller/Product
        public ActionResult Index(int? page)
        {
            //int count = (int)Repository.GetValue<int>("DECLARE @return_value Int EXEC @return_value = [dbo].[GetCountProduct] SELECT	@return_value");
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //ViewBag.pageCount = count;
            //ViewBag.pageNumber = pageNumber;
            //ViewBag.pageSize = pageSize;
            //if (count<=((pageNumber-1)*pageSize))return View(new List<ViewProduct>());
            //var query = string.Format("EXEC [dbo].[ProcGetPageProduct] @number = {0}, @size = {1}",pageNumber,pageSize);
            //var pr = Repository.GetTable<Product>(query);
            
            //if (pr != null)
            //{
            //    var cat = RepositoryCategory.GetAll();
            //    var users = RepositoryUser.GetAll();
            //    var m = pr.Select(p =>
            //    {
            //        var pv=(ViewProduct)Mapper.Map(p, typeof(Product), typeof(ViewProduct));
            //        pv.UserSeller = users.First(i=>i.Id==pv.UserSellerID).UserName;
            //        pv.Category = cat.First(i => i.CategoryId==pv.CategoryId).Name;
            //        return pv;
            //    });
            //    return View(m);
            //}
            return View(new List<ViewProduct>());
        }

        // GET: Seller/Product/Details/5
        public ActionResult Details(int id)
        {
            var p = Repository.GetById(id);
            var pv = (ViewProduct)Mapper.Map(p, typeof(Product), typeof(ViewProduct));
            //pv.UserSeller = RepositoryUser.GetById(pv.UserSellerID).UserName;
            //pv.Category = RepositoryCategory.GetById(pv.CategoryId).Name;
            return View(pv);
        }

        
    }
}
