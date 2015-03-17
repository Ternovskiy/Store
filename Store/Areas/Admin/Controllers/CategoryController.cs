using System;
using System.Linq;
using System.Web.Mvc;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using DataModul.IRepository;
using Store.Areas.Admin.Models;
using Store.Mappers;
using Store.Models;

namespace Store.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        public CategoryController(IRepositoryCategory repository, IMapper mapper)
        {
            Repository = repository;
            ModelMapper = mapper;
        }
        IRepositoryCategory Repository { get; set; }

        public IMapper ModelMapper { get; set; }
        // GET: Category
        public ActionResult Index()
        {
            var d = Repository.GetAll();
            var c = d.Select(p => (ViewCategory) ModelMapper.Map(p, typeof (Category), typeof (ViewCategory)));
            return View(c);
        }		        

        // GET: Category/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(ViewCategory collection)
        {
            if (ModelState.IsValid)
                try
                {
                    var c = (Category) ModelMapper.Map(collection, typeof (ViewCategory), typeof (Category));
                    Repository.Save(c);
                    //logger.Info(User.Identity.Name + " добавил в базу Category.");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //logger.Error(User.Identity.Name + " - " + ex.Message);
                    ModelState.AddModelError("", ex.Message);
                }
            return View();
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var c = (ViewCategory) ModelMapper.Map(Repository.GetById(id), typeof (Category), typeof (ViewCategory));
            
            return View(c);
            //return View(Repository.GetByIdCategory(id));
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(ViewCategory collection)
        {
            if (ModelState.IsValid)
                try
                {

                    var c = (Category)ModelMapper.Map(collection, typeof(ViewCategory), typeof(Category));
                    Repository.Save(c);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                }
            return View();
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var c = (ViewCategory)ModelMapper.Map(Repository.GetById(id), typeof(Category), typeof(ViewCategory));
            return View(c);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category collection)
        {
            try
            {
                Repository.Delete(collection.CategoryId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //logger.Error(User.Identity.Name + " - " + ex.Message);
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
