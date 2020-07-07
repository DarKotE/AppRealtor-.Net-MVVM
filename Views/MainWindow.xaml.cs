using System;
using System.Threading.Tasks;
using System.Windows;
using Esoft.ViewModels;

namespace Esoft.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {

        public delegate void Refresh();
        public event Refresh RefreshEvent;
        
        public MainWindow()
        {
            InitializeComponent();
            RefreshView();
        }
        private void RefreshView()
        {
            var mainVM = new MainVM();
            DataContext = null;
            DataContext = mainVM;

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
            }
        }


        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
            cbApartment.Text = String.Empty;
            cbStreet.Text = String.Empty;
        }
        

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            App.CurrentItemId = default;
            RefreshEvent += new Refresh(RefreshView);
            var winAdd = new HouseAddWindow { UpdateActor = RefreshEvent };
            winAdd.Show();
        }

        private async void tbEdit_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            RefreshEvent += new Refresh(RefreshView);
            var winAdd = new HouseEditWindow {UpdateActor = RefreshEvent};
            winAdd.Show();

        }

        private void tbComplexWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var сomplexWindow = new SecondWindow();
            сomplexWindow.ShowDialog();
        }

        private void tbApartmentWindow_OnClick(object sender, RoutedEventArgs e)
        {
            var apartmentWindow = new ThirdWindow();
            apartmentWindow.ShowDialog();
        }

    }
}


