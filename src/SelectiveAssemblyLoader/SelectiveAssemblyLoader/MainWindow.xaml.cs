using DotNetExperiments.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotNetExperiments.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = AppState.assemblyLoader;
        }

        private void btnLoadLibraries_Click(object sender, RoutedEventArgs e) {
            var moduleFilter = new ModuleFilter() {
                allowedModuleNames = AppState.assemblyLoader.dllNames.Split(','),
            };
            var dllNames = AssemblyLoader.filterAssemblies(moduleFilter);
            AssemblyLoader.loadAssemblies(dllNames);
        }

        private void btnQueryMem_Click(object sender, RoutedEventArgs e) {
            AppState.assemblyLoader.queryMemory();
        }
    }
}
