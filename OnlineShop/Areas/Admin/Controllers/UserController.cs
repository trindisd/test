using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
          
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encrypt = Encryptor.MD5Hash(user.Password);

                user.Password = encrypt;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
            
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        
        public ActionResult Edit(long id) {
            var user = new UserDao().GetByID(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
         
           if (ModelState.IsValid)
            {
                var dao = new UserDao();
                // var encrypt = Encryptor.MD5Hash(user.Password);

                //  user.Password = encrypt;

                var res = dao.Update(user);
                if (res)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhập user không thành công");
                }
            }
            return View("Index");

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}