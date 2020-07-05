using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Esoft.Classes.ViewModels;

namespace Esoft.Views
{
    /// <summary>
    /// Interaction logic for HouseEditWindow.xaml
    /// </summary>
    public partial class HouseEditWindow 
    {
        internal Delegate UpdateActor;
        public HouseEditWindow()
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
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}


