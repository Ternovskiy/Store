using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DataModul.BaseRepository;
using DataModul.IRepository;
using DataModul.ViewModel;
using Microsoft.AspNet.Identity;
using PagedList;
using Store.Areas.Admin.Models;
using Store.Mappers;
using DataModul.DomainModel;
namespace Store.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        public UserController(IRepositoryUser repository, IMapper mapper)
        {
            Repository = repository;
            ModelMapper = mapper;
        }
        IRepositoryUser Repository { get; set; }

        
        public IMapper ModelMapper { get; set; }
        // GET: Admin/User
        public ActionResult Index(int? page)
        {
            var users = Repository.GetAll();

            var viewusers = users.Where(p=>p.Id!=User.Identity.GetUserId()).Select(
                p =>
                {
                    ViewUser vu = (ViewUser)ModelMapper.Map(p, typeof(DataModul.DomainModel.User), typeof(ViewUser));
                    var ru = Repository.GetUserRole(p.Id);
                    if(ru!=null)
                    foreach (UserRole role in ru)
                    {
                        if (role.Name == "admin") vu.Admin = true;
                        else
                            if (role.Name == "seller") vu.Seller = true;
                            else
                                if (role.Name == "user") vu.User = true;
                    }
                        return vu;
                }
                );
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(viewusers.ToPagedList(pageNumber, pageSize));
        }


        // POST: Admin/User/Edit/5
        [HttpPost]
        public ActionResult Edit(ViewUser collection)
        {
            SetUserRole(collection);
            if (Request.UrlReferrer != null) return Redirect(Request.UrlReferrer.PathAndQuery);
            return RedirectToAction("Index");
        }



        public void SetUserRole(ViewUser user)
        {
            var ur = Repository.GetUserRole(user.Id);
            if (user.Admin)
            {
                if (ur.FirstOrDefault(p => p.Name == "admin") == null)
                {
                    Repository.SetUserRole(user.Id, "1");
                }
            }
            else
            {
                if (ur.FirstOrDefault(p => p.Name == "admin") != null)
                    Repository.RemoveUserRole(user.Id, "1");
            }

            if (user.Seller)
            {
                if (ur.FirstOrDefault(p => p.Name == "seller") == null)
                {
                    Repository.SetUserRole( user.Id, "2");
                }
            }
            else
            {
                if (ur.FirstOrDefault(p => p.Name == "seller") != null)
                    Repository.RemoveUserRole( user.Id, "2");
            }

            if (user.User)
            {
                if (ur.FirstOrDefault(p => p.Name == "user") == null)
                {
                    Repository.SetUserRole( user.Id, "3");
                }
            }
            else
            {
                if (ur.FirstOrDefault(p => p.Name == "user") != null)
                    Repository.RemoveUserRole( user.Id, "3");
            }
        }
    }
}
