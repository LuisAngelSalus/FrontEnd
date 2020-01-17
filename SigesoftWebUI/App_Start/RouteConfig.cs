using System.Web.Mvc;
using System.Web.Routing;

namespace SigesoftWebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "General_login", "ingresar/",
              new { controller = "Generals", action = "Login" },
              new[] { "SigesoftWebUI.Controllers" }
            );

            routes.MapRoute(
               "General_logout", "salir/",
               new { controller = "Generals", action = "Logout" },
               new[] { "SigesoftWebUI.Controllers" }
           );

            routes.MapRoute(
              "General_notauthorized",
              "notauthorized/",
              new { controller = "Generals", action = "Notauthorized" },
              new[] { "SigesoftWebUI.Controllers" }
            );

            routes.MapRoute(
                "Sigesoft", "Sigesoft/",
                new { controller = "Generals", action = "Index" },
                new[] { "SigesoftWebUI.Controllers" }
            );

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Generals", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}