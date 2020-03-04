using MovieShop.MVC.Filters;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) //global filter, apply for each and every method 
        {
            //filters.Add(new HandleErrorAttribute()); 

            filters.Add(new MovieShopExceptionFilter());
        }
    }
}
