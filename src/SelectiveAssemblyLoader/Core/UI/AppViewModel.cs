using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.UI {
    public class AppViewModel : ViewModelBase {
        public string dllNames {
            get {
                return getProp<string>("dllNames");
            } set {
                setProp("dllNames", value);
            }
        }
        public string memorySize {
            get {
                return getProp<string>("memorySize");
            } set {
                setProp("memorySize", value);
            }
        }
        public AppViewModel queryMemory() {
            var size = Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024);
            this.memorySize = string.Format("{0} MB", size);
            return this;
        }
    }
}
