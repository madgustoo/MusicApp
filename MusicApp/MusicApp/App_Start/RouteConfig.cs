using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "Search",
              "search/{searchTerm}",
              new { controller = "Search", action = "Index", searchTerm = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Profile",
                "profile/{artistId}",
                new { controller = "Profile", action = "Index", artistId = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Album",
                "profile/{artistId}/album/{albumId}",
                new { controller = "Profile", action = "Album", artistId = UrlParameter.Optional, albumId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
