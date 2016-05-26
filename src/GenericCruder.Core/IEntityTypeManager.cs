using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETL.GenericCruder.Core
{
    public interface IEntityTypeManager
    {
        void RegisterAssembly(Assembly assembly);
        void RegisterAssembly(string assemblyName);
        void RegisterAssembly(Assembly assembly, IEnumerable<string> namespaces);
        void RegisterAssembly(string assemblyName, IEnumerable<string> namespaces);

        Type GetRegistratedType(string typeName);
        IEnumerable<Type> GetTypesInNamespace(string @namespace);
        IEnumerable<string> GetRegistratedNamespaces();
    }
}
