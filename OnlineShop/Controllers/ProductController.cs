using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index( int page =1 , int pageSize = 2)
        {
            var dao = new ProductDao();
            var model = dao.ListAllProductPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Detail(string metatitle)
        {
            var model = new ProductDao().Detail(metatitle);
            return View(model);

        }
      
     
    }
}