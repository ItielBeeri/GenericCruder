using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public class BetterJsonResult : JsonResult
    {
        public BetterJsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            SerializerSettings = new JsonSerializerSettings();
        }

        public HttpStatusCode? HttpStatusCode { get; set; }

        public JsonSerializerSettings SerializerSettings { get; set; }
        
        public override void ExecuteResult(ControllerContext context)
        {
            if (context==null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            HttpResponseBase response = context.HttpContext.Response;

            if(HttpStatusCode.HasValue)
            {
                response.StatusCode = (int)HttpStatusCode.Value;
                response.TrySkipIisCustomErrors = true;
            }
            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {
                JsonSerializer serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(response.Output, Data);
            }
        }
    }
}