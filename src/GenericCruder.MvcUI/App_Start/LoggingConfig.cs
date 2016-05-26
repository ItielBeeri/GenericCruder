using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace ETL.GenericCruder.MvcUI
{
    public class LoggingConfig
    {
        public static void RegisterLoggers(HttpApplication application)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(application.Server.MapPath("~/logs/log.txt")));
            Trace.AutoFlush = true;
        }
    }
}