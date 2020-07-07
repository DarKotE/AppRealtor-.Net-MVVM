using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.Complex;
using Esoft.Util.Commands;
using Esoft.Util.Constants;
using Esoft.Util.Validators;

namespace Esoft.ViewModels.Complexes
{
    public class ComplexVM 
    {
        private string _message;
        private readonly ComplexAdapter _complexAdapter; 

        public ComplexVM()
        {
            _complexAdapter = new ComplexAdapter();

            Validator = new Validator();

            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);

            
            CurrentComplex = new ComplexWithHouses();
            StatusList = new List<string> {"План", "Строительство", "Реализация"};


            CurrentComplex.IdComplex = App.CurrentItemId;
            CurrentComplex = _complexAdapter.GetComplexWithHouses(CurrentComplex);

            CurrentStatus =
                StatusList.FirstOrDefault(
                    item => item == CurrentComplex.StatusConstructionHousingComplexName);

        }

        public string CurrentStatus { get; set; }

        public Validator Validator { get; }


        public ComplexWithHouses CurrentComplex { get; set; }

        public List<string> StatusList { get; set; }

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
            }
        }
        
        public void Save(object param)
        {
            _message = Validator.ValidateComplex(CurrentComplex);
            if (String.IsNullOrWhiteSpace(_message) && (_complexAdapter.SetComplex(CurrentComplex)))
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
            _message = Validator.ValidateComplex(CurrentComplex);
            if ((String.IsNullOrWhiteSpace(_message)) && (_complexAdapter.AddComplex(CurrentComplex)))
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
        
    }
}
