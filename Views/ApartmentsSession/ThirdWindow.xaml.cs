using System.Threading.Tasks;
using System.Windows;
using Esoft.ViewModels.Apartments;
using Esoft.Views.ComplexesSession;

namespace Esoft.Views.ApartmentsSession
{
    /// <summary>
    /// Interaction logic for .xaml
    /// </summary>
    public partial class ThirdWindow 
    {

        public delegate void Refresh();
        public event Refresh RefreshEvent;
        

        private void RefreshView()
        {
            var secondVM = new ThirdVM();
            DataContext = null;
            DataContext = secondVM;
        }


        public ThirdWindow()
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

            cbAddress.Text = default;
            cbComplex.Text = default;
            cbFloor.Text = default;
            cbPorch.Text = default;
            cbStatus.Text = default;
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
            var winAdd = new ApartmentAddWindow() { UpdateActor = RefreshEvent };
            winAdd.Show();
        }

        private async void tbEdit_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Delay(100);
            RefreshEvent += new Refresh(RefreshView);
            var winEdit = new ApartmentEditWindow() { UpdateActor = RefreshEvent};
            winEdit.Show();
        }



        private void BtnCancel_OnClick__Click(object sender, RoutedEventArgs e)
        {
            cbAddress.Text = default;
            cbComplex.Text = default;
            cbFloor.Text = default;
            cbPorch.Text = default;
            cbStatus.Text = default;
        }
    }
}


