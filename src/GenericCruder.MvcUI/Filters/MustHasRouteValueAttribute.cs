using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple=true)]
    public class MustHasRouteValueAttribute : ActionFilterAttribute
    {
        public string RouteValueName { get; set; }
        public MustHasRouteValueAttribute(string routeValueName)
        {
            RouteValueName = routeValueName;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(!filterContext.RouteData.Values.ContainsKey(RouteValueName))
            {
                Redirection redirection = Redirection.OpenRedirection(filterContext.HttpContext, "ValueMissing", "Error", new RouteValueDictionary() { { "Valuename", RouteValueName } });
                filterContext.Result = redirection.GetResult();
            }
        }
    }
}