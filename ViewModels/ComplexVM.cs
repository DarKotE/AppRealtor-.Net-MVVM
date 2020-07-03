using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Esoft.Classes;
using Esoft.Classes.Commands;
using Esoft.Classes.DataAdapters;
using Esoft.Classes.Models.Complex;
using Esoft.Classes.Validators;

namespace Esoft.ViewModels
{
    public class ComplexVM : INotifyPropertyChanged
    {
        
        public HouseAdapter HouseAdapter { get; }
        public ComplexAdapter ComplexAdapter { get; }

        public ComplexVM()
        {

            Validator = new Validator();
            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);
            HouseAdapter = new HouseAdapter();
            ComplexAdapter = new ComplexAdapter();
            CurrentComplex = new Complex();
            StatusList = new List<string>();
            StatusList.Add("План");
            StatusList.Add("Строительство");
            StatusList.Add("Реализация");
            CurrentComplex.IdComplex = App.Id;
            CurrentComplex = ComplexAdapter.GetComplex(CurrentComplex);
        }
        
        public Validator Validator { get; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get =>
                _selectedStatus;
            set
            {
                _selectedStatus = value;
                switch (_selectedStatus)
                {
                    case "План":
                        if (CurrentComplex != null)
                            CurrentComplex.StatusConstructionHousingComplex = Const.StatusConstructionValue.Plan;
                        break;
                    case "Строительство":
                        if (CurrentComplex != null)
                            CurrentComplex.StatusConstructionHousingComplex = Const.StatusConstructionValue.Build;
                        break;
                    case "Реализация":
                        if (CurrentComplex != null)
                            CurrentComplex.StatusConstructionHousingComplex = Const.StatusConstructionValue.Sell;
                        break;
                }

                OnPropertyChanged(nameof(SelectedStatus));

            }
        }

        private List<string> _statusList;

        public List<string> StatusList
        {
            get =>
                _statusList;
            set
            {
                _statusList = value;
                OnPropertyChanged(nameof(StatusList));

            }
        }


        private string _message;
        public void Save(object param)
        {
            _message = Validator.Validate(CurrentComplex);
            if (String.IsNullOrWhiteSpace(_message) && (ComplexAdapter.SetComplex(CurrentComplex)))
            {
                MessageBox.Show("Обновлено");
            }
            else
            {
                MessageBox.Show(!String.IsNullOrWhiteSpace(_message)
                    ? _message
                    : "При обновлении произошла ошибка");
            }

        }

        public void Add(object param)
        {
            _message = Validator.Validate(CurrentComplex);
            if ((String.IsNullOrWhiteSpace(_message)) && (ComplexAdapter.AddComplex(CurrentComplex)))
            {
                MessageBox.Show("Добавлено");
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(_message))
                {
                    MessageBox.Show(_message);
                }
                else
                {
                    MessageBox.Show("При добавлении произошла ошибка");
                }
            }

        }



        public Complex CurrentComplex { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

    }
}
