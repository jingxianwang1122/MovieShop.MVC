using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Filters
{
    public class MovieShopExceptionFilter:HandleErrorAttribute
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext filterContext) //class called HttpContext, build by Microsoft, the ExceptionContext is derived from the HttpContest
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            var dateExceptionHappened = DateTime.Now.TimeOfDay.ToString();
            //set breakpoint on the following line to see what the requested path and query is
            var pathAndQuery = filterContext.HttpContext.Request.Path + filterContext.HttpContext.Request.QueryString;
            // throw new FileNotFoundException();
            // log the error using logging Frameworks such as nLog, SeriLog, log4net etc. (3rd party)-download through NuGet
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500; //whenever there is an exception, the status code should be 500
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            try
            {
                Logger.Info("This route is wrong:" + pathAndQuery);
                //System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Goodbye cruel world");
            }
            base.OnException(filterContext);
        }
    }
}