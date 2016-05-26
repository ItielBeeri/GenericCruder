using ETL.GenericCruder.MvcUI.Infrastructure;
using ETL.GenericCruder.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETL.GenericCruder.MvcUI.Controllers
{
    public class CrudHtmlUiController : Controller
    {
        [MustHasRouteValue("appName")]
        [MustHasRouteValue("entityType")]
        public ActionResult Index(TypeIdentityVM typeIdentity)
        {
            return View(typeIdentity);
        }
    }
}