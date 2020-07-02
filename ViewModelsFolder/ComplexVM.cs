using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Esoft.ClassFolder;
using Esoft.ClassFolder.ModelsFolder;
using Esoft.CommandsFolder;

namespace Esoft.ViewModelsFolder
{
    public class ComplexVM : INotifyPropertyChanged
    {

        private string message;
        public DataController DataController { get; }

        

        public ComplexVM()
        {
            Validator = new Validator();
            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);
            DataController = new DataController();
            CurrentComplex = new Complex();
            StatusList = new List<string>();
            StatusList.Add("План");
            StatusList.Add("Строительство");
            StatusList.Add("Реализация");
            CurrentComplex.IdComplex = App.Id;
            CurrentComplex = DataController.Read(CurrentComplex);
           


        }



        public Validator Validator { get; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                switch (_selectedStatus)
                {
                    case "План":
                        if (CurrentComplex != null) CurrentComplex.StatusConstructionHousingComplex = "1";
                        break;
                    case "Строительство":
                        if (CurrentComplex != null) CurrentComplex.StatusConstructionHousingComplex = "2";
                        break;
                    case "Реализация":
                        if (CurrentComplex != null) CurrentComplex.StatusConstructionHousingComplex = "3";
                        break;
                }
                OnPropertyChanged(nameof(SelectedStatus));

            }
        }
        private List<string> _statusList;
        public List<string> StatusList
        {
            get => _statusList;
            set
            {
                _statusList = value;
                OnPropertyChanged(nameof(StatusList));

            }
        }


        public void Save(object param)
        {
            message = Validator.Validate(CurrentComplex);
            if (String.IsNullOrWhiteSpace(message) && (DataController.Update(CurrentComplex)))
            {
                MessageBox.Show("Обновлено");
            }
            else
            {
                MessageBox.Show(!String.IsNullOrWhiteSpace(message) ? 
                    message :
                    "При обновлении произошла ошибка");
            }

        }

        public void Add(object param)
        {
            message = Validator.Validate(CurrentComplex);
            if ((String.IsNullOrWhiteSpace(message)) && (DataController.Create(CurrentComplex)))
            {
                MessageBox.Show("Добавлено");
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show(message);
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
