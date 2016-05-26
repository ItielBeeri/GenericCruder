using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public class AllowCorsAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.WriteCorsHeaders();
            //filterContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            //filterContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE");
            //filterContext.HttpContext.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type");
        }
    }
}