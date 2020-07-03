using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Esoft.Classes;
using Esoft.Classes.DataAdapters;
using Esoft.Classes.Models.Complex;
using Esoft.Classes.Models.House;
using Esoft.CommandsFolder;

namespace Esoft.ViewModelsFolder
{
    public class HouseVM : INotifyPropertyChanged
    {

        
        public HouseAdapter HouseAdapter { get; }
        public ComplexAdapter ComplexAdapter { get; }



        public HouseVM()
        {
            Validator = new Validator();
            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);
            HouseAdapter = new HouseAdapter();
            ComplexAdapter = new ComplexAdapter();
            CurrentHouse = new House();
            HouseList = HouseAdapter.GetAllHouseInComplex();
            ComplexList = ComplexAdapter.GetAllComplex();
            CurrentHouse.IdHouse = App.Id;
            CurrentHouse = HouseAdapter.Read(CurrentHouse);

        }

        public List<HouseInComplex> HouseList { get; set; }


        public Validator Validator { get; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        private Complex _selectedComplex;
        public Complex SelectedComplex
        {
            get => _selectedComplex;
            set
            {
                _selectedComplex = value;
                if (CurrentHouse != null) CurrentHouse.IdComplex = _selectedComplex.IdComplex;
                OnPropertyChanged(nameof(SelectedComplex));

            }
        }
        private List<Complex> _complexList;
        public List<Complex> ComplexList
        {
            get => _complexList;
            set
            {
                _complexList = value;
                OnPropertyChanged(nameof(ComplexList));

            }
        }

        private string _message;
        public void Save(object param)
        {
            _message = Validator.Validate(CurrentHouse);
            if ((String.IsNullOrWhiteSpace(_message)) && (HouseAdapter.Update(CurrentHouse)))
            {
                MessageBox.Show("Обновлено");
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(_message))
                {
                    MessageBox.Show(_message);
                }
                else
                {
                    MessageBox.Show("При обновлении произошла ошибка");
                }
            }

        }

        public void Add(object param)
        {
            _message = Validator.Validate(CurrentHouse);
            if (String.IsNullOrWhiteSpace(_message) && (HouseAdapter.Create(CurrentHouse)))
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
        
        public House CurrentHouse { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
