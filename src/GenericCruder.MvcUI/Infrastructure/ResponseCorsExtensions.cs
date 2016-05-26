using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETL.GenericCruder.MvcUI.Infrastructure
{
    public static class ResponseCorsExtensions
    {
        public static void WriteCorsHeaders(this HttpResponseBase response)
        {
            response.AppendHeader("Access-Control-Allow-Origin", "*");
            response.AppendHeader("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE");
            response.AppendHeader("Access-Control-Allow-Headers", "X-Requested-With, Content-Type");

        }
    }
}