using System;
using Xamarin.Forms;

namespace SelectUnSelect {
    public partial class MainPage:ContentPage {
        public MainPage () {
            InitializeComponent();

            this.BindingContext = new MainPageViewModel();
        }

        private void TapGestureRecognizer_Tapped (object sender,EventArgs e) {
            Console.WriteLine();
        }

        private void TapGestureRecognizer_Tapped_1 (object sender,EventArgs e) {

        }

        private void CollectionView_SelectionChanged (object sender,SelectionChangedEventArgs e) {
            Console.WriteLine();
        }
    }
}
