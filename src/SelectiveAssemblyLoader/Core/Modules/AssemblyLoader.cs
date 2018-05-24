using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.Modules {
    public class AssemblyLoader : MarshalByRefObject {
        public string [] filterAssemblies(IAssemblyFilter filter) {
            var list = new List<string>();
            foreach(var dll in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")) {
                var assembly = Assembly.LoadFrom(dll);
                if (filter.isAllowed(assembly)) {
                    list.Add(assembly.FullName);
                }
            }
            return list.ToArray();
        }

        public static string [] loadAssemblies(IAssemblyFilter filter) {
            var helperDomain = AppDomain.CreateDomain("helperDomain");
            var assemblyLoader = (AssemblyLoader) helperDomain.CreateInstance(typeof(AssemblyLoader).Assembly.GetName().Name, typeof(AssemblyLoader).Name).Unwrap();
            var r = assemblyLoader.filterAssemblies(filter);
            AppDomain.Unload(helperDomain);
            return r;
        }
    }
}
