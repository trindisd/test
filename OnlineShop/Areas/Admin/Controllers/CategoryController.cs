using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new CategoryDao();
            var model = dao.ListAll();  
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}