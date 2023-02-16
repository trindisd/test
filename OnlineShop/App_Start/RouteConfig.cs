﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           

            routes.MapRoute(
                name: "Register", url: "dang-ky", defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
               name: "Edit", url: "Admin/User/Edit/{id}", defaults: new { controller = "User", action = "Edit", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
              name: "Login", url: "dang-nhap", defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" });


            routes.MapRoute(
              name: "Product-Detail", url: "san-pham/{metatitle}", defaults: new { controller = "product", action = "detail", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
             name: "Product", url: "san-pham", defaults: new { controller = "product", action = "index", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
             name: "AddCart", url: "them-gio-hang", defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
             namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
            name: "Cart", url: "gio-hang", defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
     name: "Payment", url: "thanh-toan", defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
     namespaces: new[] { "OnlineShop.Controllers" });
            
            routes.MapRoute(
     name: "Payment Success", url: "hoan-thanh", defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
     namespaces: new[] { "OnlineShop.Controllers" });

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineShop.Controllers" }
           );
        }
    }
}
