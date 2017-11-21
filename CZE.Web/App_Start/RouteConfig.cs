using CZE.Data;
using CZE.Data.Models;
using CZE.Web.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CZE.Web
{
    public class RouteConfig
    {
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "HomeIndex",
                url: "Home/Index",
                defaults: new { controller = "Home", action = "DashBoard", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DashBoard", id = UrlParameter.Optional }
            );
            Database.SetInitializer(new PocetnaBaza());
        }
       
    }
}
