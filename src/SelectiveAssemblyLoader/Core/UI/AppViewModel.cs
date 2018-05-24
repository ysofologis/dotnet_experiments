using System;
using System.Collections.Generic;
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
        public int memorySize {
            get {
                return getProp<int>("memorySize");
            } set {
                setProp("memorySize", value);
            }
        }
    }
}
