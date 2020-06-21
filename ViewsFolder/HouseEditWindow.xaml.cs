using System;
using System.Windows;

namespace Esoft.ViewsFolder
{
    /// <summary>
    /// Interaction logic for HouseEditWindow.xaml
    /// </summary>
    public partial class HouseEditWindow : Window
    {
        public Delegate UpdateActor;
        public HouseEditWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}


