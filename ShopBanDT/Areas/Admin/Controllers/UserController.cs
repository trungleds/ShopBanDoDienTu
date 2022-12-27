using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanDT.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 2)
        {
            var dao = new UserDao();
            var model = dao.LisAllPaging(page, pageSize);
            return View(model);
        }
    }
}