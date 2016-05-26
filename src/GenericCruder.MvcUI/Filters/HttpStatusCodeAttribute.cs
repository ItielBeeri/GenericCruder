using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public class HttpStatusCodeAttribute : ActionFilterAttribute
    {
        public int StatusCode { get; set; }
        public HttpStatusCodeAttribute(int statusCode)
        {
            StatusCode = statusCode;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode==200)
            {
                filterContext.HttpContext.Response.StatusCode = 400;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}