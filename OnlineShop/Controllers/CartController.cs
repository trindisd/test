using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using System.Web.Script.Serialization;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {

        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list= (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long ProductID, int Quantity) 
        {
            var product = new ProductDao().ViewDetail(ProductID);
            var cart = Session[CartSession];
            if(cart != null) 
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(x=>x.Product.ID == ProductID))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == ProductID)
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                
            }
            else
            {
                //tao moi doi tuong
                var item = new CartItem();
                item.Product = product;
                item.Quantity = Quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];  
            foreach(var item in sessionCart)
            {
                var jsonItem =  jsonCart.SingleOrDefault(x=>x.Product.ID==item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new {status = true});
        }
        public JsonResult Delete(long id) 
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            } 
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email  )
        {
            var order = new Order();
            order.ShipName = shipName;
            order.ShipAddress = address;
            order.ShipEmail = email;
            order.ShipMobile = mobile;
            order.CreatedDate = DateTime.Now;
            var id = new OrderDao().Insert(order);
            var cart = (List<CartItem>) Session[CartSession];
            var orderDetailDao = new OrderDetailDao();
            foreach(var item in cart)
            {
                var orderDetail = new OrderDetail();
                orderDetail.OrderID = id;
                orderDetail.ProductID = item.Product.ID;
                orderDetail.Price=item.Product.Price;
                orderDetail.Quantity= item.Product.Quantity;
                orderDetailDao.Insert(orderDetail);
            }
            return Redirect("/hoan-thanh");

        }
        public ActionResult Success()
        {
            return View();
        }
    }
}