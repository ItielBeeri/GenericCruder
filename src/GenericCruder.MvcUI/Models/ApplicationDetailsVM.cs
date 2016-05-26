using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETL.GenericCruder.MvcUI.Models
{
    public class ApplicationDetailsVM
    {
        public string AppName { get; set; }
        public List<string> TypeNames { get; set; }
    }
}