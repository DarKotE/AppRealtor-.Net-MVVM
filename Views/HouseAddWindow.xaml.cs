using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Esoft.Src.ViewModels;

namespace Esoft.Views
{
    /// <summary>
    /// Interaction logic for HouseAddWindow.xaml
    /// </summary>
    public partial class HouseAddWindow
    {
        internal Delegate UpdateActor;
        public HouseAddWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var houseVM = new HouseVM();
            this.DataContext = null;
            this.DataContext = houseVM;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UpdateActor?.DynamicInvoke();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            UpdateActor?.DynamicInvoke();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}


