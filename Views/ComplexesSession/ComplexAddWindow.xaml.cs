﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Esoft.ViewModels.Complexes;

namespace Esoft.Views.ComplexesSession
{
    /// <summary>
    /// Interaction logic for ComplexAddWindow.xaml
    /// </summary>
    public partial class ComplexAddWindow
    {
        internal Delegate UpdateActor;
        public ComplexAddWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var complexVM = new ComplexVM();
            this.DataContext = null;
            this.DataContext = complexVM;
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


