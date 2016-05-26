using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETL.GenericCruder.Core;

namespace ETL.GenericCruder.MvcUI
{
    public class UserEntitiesConfig
    {
        public static void RegisterUserEntities(IEntityTypeManager userEntitiesManager)
        {
            userEntitiesManager.RegisterAssembly("ETL.GenericCruder.UserEntities");
        }
    }
}