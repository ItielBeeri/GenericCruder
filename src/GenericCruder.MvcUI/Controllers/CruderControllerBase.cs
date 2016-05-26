using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ETL.GenericCruder.MvcUI.Infrastructure;
using System.Text;

namespace ETL.GenericCruder.MvcUI.Controllers
{
    public class CruderControllerBase : Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new BetterJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }
        protected BetterJsonResult Json(object data, HttpStatusCode statusCode)
        {
            BetterJsonResult result = (BetterJsonResult)Json(data, null, null, JsonRequestBehavior.DenyGet);
            result.HttpStatusCode = statusCode;
            return result;
        }

    }
}