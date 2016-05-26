using ETL.GenericCruder.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ETL.GenericCruder.Core
{
    public class UserEntitiesManager : IEntityTypeManager
    {
        HashSet<Assembly> _registratedAssemblies;
        HashSet<Type> _registratedTypes;

        public UserEntitiesManager()
        {
            _registratedAssemblies = new HashSet<Assembly>();
            _registratedTypes = new HashSet<Type>();
        }

        private Assembly LoadAssemblyByName(string assemblyName)
        { 
            //using Load, not LoadFrom, since LoadFrom has some disadvantages and could cause ambiguity and disorder
            Assembly asm = Assembly.Load(assemblyName);
            return asm;
        }

        public void RegisterAssembly(string assemblyName)
        {
            RegisterAssembly(LoadAssemblyByName(assemblyName));
        }

        public void RegisterAssembly(Assembly assembly)
        {
            RegisterAssembly(assembly, null);
        }

        public void RegisterAssembly(string assemblyName, IEnumerable<string> namespaces)
        {
            RegisterAssembly(LoadAssemblyByName(assemblyName), namespaces);
        }

        public void RegisterAssembly(Assembly assembly, IEnumerable<string> namespaces)
        {
            _registratedAssemblies.Add(assembly);
            IEnumerable<Type> types = assembly.GetTypes();
            if (namespaces!=null)
            {
                types = types.Where(t => namespaces.Contains(t.Namespace));
            }
            foreach (var type in types)
            {
                _registratedTypes.Add(type);
            }
        }

        public Type GetRegistratedType(string typeName)
        {
            //Type requestedType=null;
            //string[] typeNameComponents = typeName.Split('.');
            //int i = 0;
            //int maxIterations = _registratedTypes.Select(t => t.FullName.Split('.')).Max(n => n.Length);
            //while (requestedType==null && i<=maxIterations)
            //{
            //    requestedType = _registratedTypes.SingleOrDefault(t => t.FullName.Split('.').Skip(i).SequenceEqual(typeNameComponents,StringComparer.OrdinalIgnoreCase));
            //    i++;
            //}
            //return requestedType;

            return _registratedTypes.SingleOrDefault(t => TypeNameCompareHelper.IsStringMatchesTypeName(typeName, t.FullName));
        }

        public IEnumerable<Type> GetTypesInNamespace(string @namespace)
        {
            return _registratedTypes.Where(t => TypeNameCompareHelper.IsStringMatchesTypeName(@namespace, t.Namespace));
        }


        public IEnumerable<string> GetRegistratedNamespaces()
        {
            return _registratedTypes.Select(t => t.Namespace);
        }
    }
}
