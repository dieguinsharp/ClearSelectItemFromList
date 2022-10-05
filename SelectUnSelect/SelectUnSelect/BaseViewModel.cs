using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SelectUnSelect {
    public class BaseViewModel:INotifyPropertyChanged {

        public BaseViewModel () {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged (string propertyName) {
            if(!string.IsNullOrEmpty(propertyName)) {
                PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
