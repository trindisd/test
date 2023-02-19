using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var dao = new ProductDao();
            var model = dao.ListAllProductPaging(page, pagesize);
            return View(model);
        }
        public ActionResult Create()
        {
            OnlineShopDbContext db = new OnlineShopDbContext();
            var 
            var query = (from c in db.ProductCategories select new { }).ToList();
            
            return View();
        }
    }
}