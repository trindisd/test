using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Admin/Validation
        OnlineShopDbContext db = new OnlineShopDbContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult IsUserNameExist(string userName)
        {
           return Json(!db.User.Any(x=>x.UserName == userName), JsonRequestBehavior.AllowGet);
        }
    }
}