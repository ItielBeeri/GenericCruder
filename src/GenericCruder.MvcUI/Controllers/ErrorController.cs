using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETL.GenericCruder.MvcUI.Models;
using ETL.GenericCruder.MvcUI.Infrastructure;

namespace ETL.GenericCruder.MvcUI.Controllers
{
    [HttpStatusCode(400)]
    public class ErrorController : Controller
    {
        public ActionResult ApplicationNotFound(string appName)
        {
            return View((object)appName);
        }
        
        public ActionResult EntityTypeNotFound(TypeIdentityVM typeIdentity)
        {
            return View(typeIdentity);
        }

        public ActionResult ValueMissing(string valueName)
        {
            return View((object)valueName);
        }

        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}