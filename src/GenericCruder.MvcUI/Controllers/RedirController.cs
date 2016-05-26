using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETL.GenericCruder.MvcUI.Infrastructure;

namespace ETL.GenericCruder.MvcUI.Controllers
{
    public class RedirController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("~/");
        }

        public ActionResult ByRedirectionManager()
        {
            return Redirection.HasRedirection(HttpContext) ? Redirection.GetRedirection(HttpContext) : Index();
        }
    }
}