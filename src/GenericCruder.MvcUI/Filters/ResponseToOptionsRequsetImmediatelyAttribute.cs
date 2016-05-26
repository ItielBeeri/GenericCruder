using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public class ResponseToOptionsRequsetImmediatelyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod=="OPTIONS")
            {
                filterContext.HttpContext.Response.Flush();
                filterContext.Result = new ContentResult();
            }
        }
    }
}