using Pagination.Business;
using Pagination.Models;
using Pagination.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        string controllerName = "Home";
      IUserBusiness _IUB;
      
        public HomeController()
        {
           UserBusiness IUB = new UserBusiness();
            _IUB = IUB;

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //works
        public ActionResult UserLists(int? page)
        {
            int pageSize = 50;
            int pageIndex = page ?? 1;
            UserModel filterModel = new UserModel();
            List<UserModel> data = _IUB.GetUserList();
           
            IPagedList<UserModel> datapage = data.ToPagedList(pageIndex, pageSize);

            return View(datapage);

        }
        //doesn't work. changes to be made in stored procedure
        [HttpGet]
        public ActionResult UserListsP(int? page)
        {
            int pageIndex = page ?? 1;
            UserModel filterModel = new UserModel();
            List<UserModel> datapage = _IUB.GetUserList(pageIndex);
           
            return View(datapage);

        }
    }
}