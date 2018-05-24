using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.Modules {
    public class ModuleInfo {
        public string name { get; set; }
    }
    public interface IAppModule {
        ModuleInfo getInfo();
    }
}
