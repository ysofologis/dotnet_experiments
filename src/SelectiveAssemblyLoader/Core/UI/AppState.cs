using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.UI {
    public static class AppState {
        public static readonly AppViewModel assemblyLoader = new AppViewModel() {
            dllNames = "Lib1,Lib2,Lib3",
            memorySize = "0 MB",
        }.queryMemory();
    }
}
