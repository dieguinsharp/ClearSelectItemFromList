using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SelectUnSelect {
    public class MainPageViewModel: BaseViewModel {

        Item selectedItem;
        public Item SelectedItem {
            get {
                return selectedItem;
            }
            set {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        ObservableCollection<Item> items;
        public ObservableCollection<Item> Items {
            get {
                return items;
            }
            set {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public Command<Item> SelectOrUnselectItem { get; set; }

        public MainPageViewModel () {

            Items = new ObservableCollection<Item>() {
                new Item() { ID = 1, Name = "Name 1" },
                new Item() { ID = 2, Name = "Name 2" },
                new Item() { ID = 3, Name = "Name 3" },
                new Item() { ID = 4, Name = "Name 4" },
                new Item() { ID = 5, Name = "Name 5" }
            };

            SelectOrUnselectItem = new Command<Item>(_ => {

                if(this.SelectedItem != null)
                    SelectedItem.IsSelected = false;

                if(this.SelectedItem != null && _.ID == this.SelectedItem.ID) {
                    _.IsSelected = false;
                    this.SelectedItem = null;
                } else {
                    _.IsSelected = !_.IsSelected;
                    this.SelectedItem = _;
                }
            });

        }

        
    }

    public class Item : BaseViewModel {
        public int ID { get; set; }
        public string Name { get; set; }

        bool isSelected;
        public bool IsSelected {
            get {
                return isSelected;
            }
            set {
                isSelected = value;
                this.Background = IsSelected ? "#FFA500" : "#FFFFFF";
                OnPropertyChanged(nameof(IsSelected));
            }
        }
        public string Background { get; set; }
    }
}
