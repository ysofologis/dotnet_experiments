using DotNetExperiments.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib2
{
    public class Lib2Module : IAppModule {
        private const int LEAK_SIZE = 1024 * 1024 * 20;
        private static readonly byte[] memLeak = new byte[LEAK_SIZE];
        public ModuleInfo getInfo() {
            return new ModuleInfo() {
                name = this.GetType().Assembly.GetName().Name,
            };
        }
    }
}
