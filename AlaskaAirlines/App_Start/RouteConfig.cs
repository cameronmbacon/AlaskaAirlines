using System.Web.Mvc;
using System.Web.Routing;

namespace AlaskaAirlines
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{From}/{To}",
                defaults: new { controller = "Home", action = "Index", From = UrlParameter.Optional, To = UrlParameter.Optional }
            );
        }
    }
}
