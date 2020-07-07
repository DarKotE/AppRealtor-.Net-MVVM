using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Esoft.ViewModels.Apartments;

namespace Esoft.Views.ApartmentsSession
{
    /// <summary>
    /// Interaction logic for ApartmentEditWindow.xaml
    /// </summary>
    public partial class ApartmentEditWindow
    {
        internal Delegate UpdateActor;
        public ApartmentEditWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var apartmentVM = new ApartmentVM();
            this.DataContext = null;
            this.DataContext = apartmentVM;
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


