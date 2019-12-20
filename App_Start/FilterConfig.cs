using System.Web.Mvc;

namespace SetifyFinal
{
    //Adds universal attributes to pages in the API! Restricting access
    //Adds HTTP security
    
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
