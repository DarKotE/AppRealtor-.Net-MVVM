using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

using Esoft.ViewModelsFolder;

namespace Esoft.ViewsFolder
{
    /// <summary>
    /// Interaction logic for .xaml
    /// </summary>
    public partial class SecondWindow : Window
    {

        public delegate void Refresh();
        public event Refresh RefreshEvent;

        

        private async void LiveSortWorkaround()
        {
            await Task.Delay(100);
            dgHouseList.Items.SortDescriptions.Add(
                new SortDescription("City",
                ListSortDirection.Ascending));
            dgHouseList.Items.SortDescriptions.Add(
                new SortDescription("StatusConstructionHousingComplexName",
                ListSortDirection.Ascending));
        }

        private void RefreshView()
        {
            var secondVM = new SecondVM();
            this.DataContext = null;
            this.DataContext = secondVM;
            dgHouseList.Items.IsLiveSorting = true;
            LiveSortWorkaround();

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
                this.Close();
                
            }
        }


        private async void Add_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            RefreshEvent += new Refresh(RefreshView);
            ComplexAddWindow winAdd = new ComplexAddWindow();
            winAdd.UpdateActor = RefreshEvent;
            winAdd.Show();
        }

        private void tbSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            LiveSortWorkaround();
            cbStatus.Text = String.Empty;
            cbCity.Text = String.Empty;
        }

        private void cbStatus_DropDownClosed(object sender, EventArgs e)
        {
            LiveSortWorkaround();
            cbCity.Text = String.Empty;
        }

        private void cbCity_DropDownClosed(object sender, EventArgs e)
        {
            LiveSortWorkaround();
            cbStatus.Text = String.Empty;
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
            ComplexEditWindow winEdit = new ComplexEditWindow();
            winEdit.UpdateActor = RefreshEvent;
            winEdit.Show();
        }

        private void tbDelete_OnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}


