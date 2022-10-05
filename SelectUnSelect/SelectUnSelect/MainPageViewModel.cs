using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SelectUnSelect {
    public class MainPageViewModel: INotifyPropertyChanged {

        Item selectedItem;
        public Item SelectedItem {
            get {
                return selectedItem;
            } set {

                if(value != null && this.selectedItem != null && this.selectedItem.ID == value.ID)
                    value = null;

                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));

                ClearCommand.ChangeCanExecute();
            }   
        }

        ObservableCollection<Item> items;
        public ObservableCollection<Item> Items {
            get {
                return items;
            } set {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public Command ClearCommand { get; set; }

        public MainPageViewModel () {
            Items = new ObservableCollection<Item>() {
                new Item() { ID = 1, Name = "Name 1" },
                new Item() { ID = 2, Name = "Name 2" },
                new Item() { ID = 3, Name = "Name 3" },
                new Item() { ID = 4, Name = "Name 4" },
                new Item() { ID = 5, Name = "Name 5" }
            };

            ClearCommand = new Command(_ => ClearSelectedItem(), _ => this.SelectedItem != null);
        }

        public void ClearSelectedItem () {
            this.SelectedItem = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged (string propertyName) {
            if(!string.IsNullOrEmpty(propertyName)) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Item {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
