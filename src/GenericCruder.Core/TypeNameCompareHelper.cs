using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
    public static class TypeNameCompareHelper
    {
        public static bool IsStringMatchesTypeName(string testedString, string typeName)
        {
            string[] testedComponents = testedString.Split('.');
            string[] typenameComponents = typeName.Split('.');
            for (int i = 0; i < typenameComponents.Length; i++)
            {
                if (typenameComponents.Skip(i).SequenceEqual(testedComponents,StringComparer.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
