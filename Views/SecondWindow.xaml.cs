using System;
using System.Threading.Tasks;
using System.Windows;
using Esoft.Src.ViewModels;

namespace Esoft.Views
{
    /// <summary>
    /// Interaction logic for .xaml
    /// </summary>
    public partial class SecondWindow 
    {

        public delegate void Refresh();
        public event Refresh RefreshEvent;
        

        private void RefreshView()
        {
            var secondVM = new SecondVM();
            DataContext = null;
            DataContext = secondVM;
        }


        public SecondWindow()
        {
            InitializeComponent();
            RefreshView();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbSearch.Focus();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно желаете выйти?",
                "Информация",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            }
        }

        
        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
            cbStatus.Text = String.Empty;
            cbCity.Text = String.Empty;
        }
        
        private void tbApartmentWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var apartmentWindow = new SecondWindow();
            apartmentWindow.ShowDialog();
        }

        private async void Add_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            RefreshEvent += new Refresh(RefreshView);
            var winAdd = new ComplexAddWindow { UpdateActor = RefreshEvent };
            winAdd.Show();
        }

        private async void tbEdit_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            RefreshEvent += new Refresh(RefreshView);
            var winEdit = new ComplexEditWindow {UpdateActor = RefreshEvent};
            winEdit.Show();
        }
        
    }
}


