using Pagination.Business;
using Pagination.Models;
using Pagination.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data;

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
            UserModel filterModel = new UserModel();
            List<UserModel> data = _IUB.GetUserList();
            return View(data);
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
        //paged list
        public ActionResult UserLists(int? page)
        {
            int pageSize = 50;
            int pageIndex = page ?? 1;
            UserModel filterModel = new UserModel();
            List<UserModel> data = _IUB.GetUserList();

            IPagedList<UserModel> datapage = data.ToPagedList(pageIndex, pageSize);

            return View(datapage);

        }
        //Custom paging
        [HttpGet]
        public ActionResult UserListsP(int? page)
        {
            int maxRows = 10;
            double mRows = maxRows;
            int startIndex;
            int pageIndex = page ?? 1;
            int tot = (int)Math.Ceiling((_IUB.TotalRecords()) / mRows);
            ViewBag.TotalPages = tot;
            startIndex = ((pageIndex - 1) * maxRows) + 1;
            ViewBag.CurrentPageIndex = pageIndex;
            UserModel filterModel = new UserModel();
            List<UserModel> datapage = _IUB.GetUserList(startIndex, maxRows);

            return View(datapage);

        }
        public ActionResult PagedList(int? page)
        {
            int maxRows = 10;
            double mRows = maxRows;
            //int startIndex;
            int pageIndex = page ?? 1;
            int tot = (int)Math.Ceiling((_IUB.TotalRecords()) / mRows);
            ViewBag.TotalPages = tot;
            //startIndex = ((pageIndex - 1) * maxRows) + 1;
            ViewBag.CurrentPageIndex = pageIndex;
            UserModel filterModel = new UserModel();
            List<UserModel> datapage = _IUB.GetUserListP(pageIndex, maxRows);

            return View(datapage);

        }
        [HttpPost]
        public JsonResult GetList()
        {
            int totalRecord = 0;
            int filterRecord = 0;

            var draw = Request.Form["draw"].FirstOrDefault();

            int pageSize = (int?)Convert.ToInt32(Request.Form["length"].FirstOrDefault()) ?? 0;
            

            int skip = (int?)Convert.ToInt32(Request.Form["start"].FirstOrDefault()) ?? 0;

            totalRecord = _IUB.TotalRecords();

            var empList = _IUB.GetUserListP(skip, pageSize);
            filterRecord = empList.Count();

            var returnObj = new { draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList };
            return Json(returnObj);
        }
    }
}

