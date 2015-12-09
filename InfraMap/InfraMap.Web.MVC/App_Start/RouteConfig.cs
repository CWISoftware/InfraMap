using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InfraMap.Web.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Mapa",
                url: "Mapa/{action}",
                defaults: new { controller = "Mapa", action = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EdicaoMapa",
                url: "Mapa/{sede}/{andar}",
                defaults: new { controller = "Mapa", action = "Index", sede = UrlParameter.Optional, andar = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
