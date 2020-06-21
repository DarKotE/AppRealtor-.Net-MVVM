using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using Esoft.ViewModelsFolder;

namespace Esoft.ViewsFolder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {

        public delegate void Refresh();
        public event Refresh RefreshEvent;

        private async void LiveSortWorkaround()
        {
            await Task.Delay(100);
            dgHouseList.Items.SortDescriptions.Add(
                new SortDescription("NameHousingComplex",
                ListSortDirection.Ascending));
            dgHouseList.Items.SortDescriptions.Add(
                new SortDescription("Street",
                ListSortDirection.Ascending));
            dgHouseList.Items.SortDescriptions.Add(
                new SortDescription("NumberHouse",
                ListSortDirection.Ascending));
        }

        private void RefreshView()
        {
            var mainVM = new MainVM();
            this.DataContext = null;
            this.DataContext = mainVM;
            dgHouseList.Items.IsLiveSorting = true;
            LiveSortWorkaround();

        }

        public MainWindow()
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


        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            App.Id = 0;
            RefreshEvent += new Refresh(RefreshView);
            HouseAddWindow winAdd = new HouseAddWindow();
            winAdd.UpdateActor = RefreshEvent;
            winAdd.Show();
        }

        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiveSortWorkaround();
            cbApartment.Text = String.Empty;
            cbStreet.Text = String.Empty;
        }

        private void cbApartment_DropDownClosed(object sender, EventArgs e)
        {
            LiveSortWorkaround();
            cbStreet.Text = String.Empty;
        }

        private void cbStreet_DropDownClosed(object sender, EventArgs e)
        {
            LiveSortWorkaround();
            cbApartment.Text = String.Empty;
        }



        private void tbApartmentWindow_OnClick(object sender, RoutedEventArgs e)
        {
            ViewsFolder.SecondWindow appartmentWindow = new ViewsFolder.SecondWindow();
            appartmentWindow.ShowDialog();
        }

        private async void tbEdit_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            RefreshEvent += new Refresh(RefreshView);
            HouseEditWindow winAdd = new HouseEditWindow();
            winAdd.UpdateActor = RefreshEvent;
            winAdd.Show();

        }

        private void tbDelete_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}


