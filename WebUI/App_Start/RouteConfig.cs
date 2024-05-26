using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Game",
                    action = "List",
                    category = (string)null,
                    page = 1
                }
            ); // /

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new {
                    controller = "Game",
                    action = "List",
                    category = (string)null,
                },
                constraints: new { page = @"\d+"}
            ); // /page1

            routes.MapRoute(
                null,
                "{category}",
                new
                {
                    controller = "Game",
                    action = "List"
                },
                new { page = @"\d+" }
              ); // /category

            routes.MapRoute( null, "{controller}/{action}"); // /category/page3
        }
    }
}


// Page2
// rpg/page3