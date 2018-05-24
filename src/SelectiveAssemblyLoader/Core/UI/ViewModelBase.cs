using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExperiments.UI {
    public abstract class ViewModelBase : INotifyPropertyChanged {
        private Dictionary<string, object> _state = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void setProp<ModelT>(string propName, ModelT propValue = default(ModelT)) {
            _state[propName] = propValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName) { });
        }
        protected ModelT getProp<ModelT>(string propName) {
            return (ModelT) _state[propName];
        }
    }
}
