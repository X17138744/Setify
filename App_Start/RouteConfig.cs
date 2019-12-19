using System.Web.Mvc;
using System.Web.Routing;

namespace SetifyFinal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //New Routing Techniques for Artists for path instead of using generic path.
            routes.MapRoute(
                "TracksByReleaseDate",
                "artist/tracks/{year}/{month}",
                new { controller = "Artist", action = "ByReleaseMonth" },
                //Add Constraints to the routes on year and date verbatim string on pathing
                new { year = @"\d{4}", month = @"\d{2}" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
