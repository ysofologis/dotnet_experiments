using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.Modules {
    [Serializable]
    public class ModuleFilter: IAssemblyFilter {
        public string [] allowedModuleNames { get; set; }

        public bool isAllowed(Assembly assembly) {
            var appModuleType = assembly.GetTypes().Where(x => typeof(IAppModule).IsAssignableFrom(x)).SingleOrDefault();
            if (appModuleType != null) {
                var appModule = Activator.CreateInstance(appModuleType) as IAppModule;
                var moduleInfo = appModule.getInfo();
                return allowedModuleNames.Any(x => x == moduleInfo.name);
            } else {
                return false;
            }
        }
    }
}
