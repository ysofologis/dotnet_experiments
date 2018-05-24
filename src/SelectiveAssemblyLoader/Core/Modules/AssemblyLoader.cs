using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.Modules {
    public class AssemblyLoader : MarshalByRefObject {
        public string [] validateAssemblies(IAssemblyFilter filter) {
            var list = new List<string>();
            foreach(var dll in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")) {
                var assembly = Assembly.LoadFrom(dll);
                if (filter.isAllowed(assembly)) {
                    list.Add(assembly.ManifestModule.FullyQualifiedName);
                }
            }
            return list.ToArray();
        }

        public static string [] filterAssemblies(IAssemblyFilter filter) {
            var helperDomain = AppDomain.CreateDomain("helperDomain");
            var assemblyLoader = (AssemblyLoader) helperDomain.CreateInstance(typeof(AssemblyLoader).Assembly.GetName().Name, typeof(AssemblyLoader).FullName).Unwrap();
            var r = assemblyLoader.validateAssemblies(filter);
            AppDomain.Unload(helperDomain);
            return r;
        }
        public static Assembly[] loadAssemblies(string[] assemblyNames) {
            List<Assembly> list = new List<Assembly>();
            foreach (var n in assemblyNames) {
                var assembly = Assembly.LoadFrom(n);
                var appModuleType = assembly.GetTypes().Where(x => typeof(IAppModule).IsAssignableFrom(x)).SingleOrDefault();
                var appModule = Activator.CreateInstance(appModuleType) as IAppModule;
                var moduleInfo = appModule.getInfo();
                list.Add(assembly);
            }
            return list.ToArray();
        }
    }
}
