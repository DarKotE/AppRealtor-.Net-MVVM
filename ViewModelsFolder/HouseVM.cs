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
    public class HouseVM : INotifyPropertyChanged
    {

        private string message;
        public DataController DataController { get; }

        

        public HouseVM()
        {
            Validator = new Validator();
            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);
            DataController = new DataController();
            CurrentHouse = new House();
            HouseList = DataController.GetAllHouseInComplex();
            ComplexList = DataController.GetAllComplex();
            CurrentHouse.IdHouse = App.Id;
            CurrentHouse = DataController.Read(CurrentHouse);
           


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
                CurrentHouse.IdComplex = _selectedComplex.IdComplex;
                OnPropertyChanged("SelectedComplex");

            }
        }
        private List<Complex> _complexList;
        public List<Complex> ComplexList
        {
            get => _complexList;
            set
            {
                _complexList = value;
                OnPropertyChanged("ComplexList");

            }
        }


        public void Save(object param)
        {
            message = Validator.Validate(CurrentHouse);
            if (message.Equals(String.Empty) && (DataController.Update(CurrentHouse)))
            {
                MessageBox.Show("Обновлено");
            }
            else
            {
                if (!message.Equals(String.Empty))
                {
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("При обновлении произошла ошибка");
                }
            }

        }

        public void Add(object param)
        {
            message = Validator.Validate(CurrentHouse);
            if (message.Equals(String.Empty) && (DataController.Create(CurrentHouse)))
            {
                MessageBox.Show("Добавлено");
            }
            else
            {
                if (!message.Equals(String.Empty))
                {
                    MessageBox.Show(message);
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
