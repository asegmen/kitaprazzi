﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kitaprazzi.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Kitap",
                url: "kitap/detay/{id}",
                defaults: new { controller = "Content", action = "Book", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "YayinEvi",
                url: "yayin-evi/detay/{id}",
                defaults: new { controller = "Content", action = "Publisher", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
