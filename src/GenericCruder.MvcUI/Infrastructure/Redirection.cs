using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public class Redirection
    {
        private const string REDIRECTION_KEY = "redirection";

        public static Redirection OpenRedirection(HttpContextBase httpContext, string actionName, string controllerName)
        {
           return OpenRedirection(httpContext, controllerName, actionName, null);
        }
        public static Redirection OpenRedirection(HttpContextBase httpContext, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            Redirection redir = new Redirection()
            {
                ControllerName = controllerName,
                ActionName = actionName,
                RouteValues = routeValues
            };
            return OpenRedirection(httpContext, redir);
        }
        public static Redirection OpenRedirection(HttpContextBase httpContext, string path)
        {
            Redirection redir = new Redirection()
            {
                Path = path
            };
            return OpenRedirection(httpContext, redir);
        }
        public static Redirection OpenRedirection(HttpContextBase httpContext, Redirection redirection)
        {
            httpContext.Items[REDIRECTION_KEY] = redirection;
            return redirection;
        }
        
        public static bool HasRedirection(HttpContextBase httpContext)
        {
            return (httpContext.Items[REDIRECTION_KEY] as Redirection) != null;
        }
        
        public static ActionResult GetRedirection(HttpContextBase httpContext)
        {
            Redirection redir = httpContext.Items[REDIRECTION_KEY] as Redirection;
            if (redir == null)
            {
                throw new ArgumentException("The context does not contain a valid Redirection object.", "httpContext");
            }
            return redir.GetResult();
        }
        
        
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Path { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
        
        public ActionResult GetResult()
        {
            if (!string.IsNullOrEmpty(ControllerName))
            {
                RouteValueDictionary routeValues = RouteValues ?? new RouteValueDictionary();
                routeValues["controller"]= ControllerName;
                routeValues["action"]= ActionName;
                return new RedirectToRouteResult(routeValues);
            }
            else if (!string.IsNullOrEmpty(Path))
            {
                return new RedirectResult(Path);
            }
            else
            {
                return new RedirectResult("~/");
            }
        }
    }
}