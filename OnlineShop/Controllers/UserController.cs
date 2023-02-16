using Model.Dao;
using Model.EF;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using OnlineShop.Common;
namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model) {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();

                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("","Tên tài khoản đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Phone= model.Phone;  
                    user.Name= model.Name;
                    var res = dao.Insert(user);
                    if (res > 0)
                    {
                        ViewBag.Sucess = " Đăng kí thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            var dao = new UserDao();
            var res = dao.Login(user.UserName, Encryptor.MD5Hash( user.Password));
            if (res)
            {
                var userSession = new UserLogin();
                userSession.UserName = user.UserName;
                Session.Add(CommonConstants.USER_SESSION, userSession);
            return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            return Redirect("/");
        }
    }
}