using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.Complex;
using Esoft.Models.House;
using Esoft.Util.Commands;
using Esoft.Util.Validators;

namespace Esoft.ViewModels
{
    public class HouseVM 
    {
        private readonly HouseAdapter _houseAdapter;
        private readonly ComplexAdapter _complexAdapter;

        private string _message;

        public HouseVM()
        {
            Validator = new Validator();

            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);

            _houseAdapter = new HouseAdapter();
            _complexAdapter = new ComplexAdapter();

            CurrentHouse = new House();
            CurrentComplex = new Complex();

            CurrentHouse.IdHouse = App.CurrentItemId;

            CurrentHouse = _houseAdapter.GetHouse(CurrentHouse);
            HouseList = _houseAdapter.GetAllHouseInComplex();
            ComplexList = _complexAdapter.GetAllComplex();

            CurrentComplex = ComplexList.FirstOrDefault(
                item => item.IdComplex == CurrentHouse.IdComplex);
            
        }

        public Complex CurrentComplex { get; set; }


        public List<HouseInComplex> HouseList { get; set; }
        public List<Complex> ComplexList { get; set; }


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
                if (CurrentHouse == null) return;
                if (_selectedComplex != null)
                    CurrentHouse.IdComplex = _selectedComplex.IdComplex;
            }
        }

     

        public void Save(object param)
        {
            _message = Validator.ValidateHouse(CurrentHouse);
            if ((String.IsNullOrWhiteSpace(_message)) && (_houseAdapter.SetHouse(CurrentHouse)))
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
            _message = Validator.ValidateHouse(CurrentHouse);
            if (String.IsNullOrWhiteSpace(_message) && (_houseAdapter.AddHouse(CurrentHouse)))
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


       



    }
}
