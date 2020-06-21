using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.ClassFolder;
using Esoft.CommandsFolder;

namespace Esoft.ViewModelsFolder

{
    public class SecondVM : INotifyPropertyChanged
    {

        private string message;
        private string searchText;


        public SecondVM()
        {
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
            DataController = new DataController();
            LoadData();
        }

        public DataController DataController { get; }

        private ObservableCollection<ComplexWithHouses> _filteredComplexList;
        public ObservableCollection<ComplexWithHouses> FilteredComplexList
        {
            get => _filteredComplexList;
            set
            {
                _filteredComplexList = value;
                OnPropertyChanged("FilteredComplexList");
            }
        }


        private ObservableCollection<ComplexWithHouses> _complexList;
        public ObservableCollection<ComplexWithHouses> ComplexList
        {
            get => _complexList;
            set
            {
                _complexList = value;
                OnPropertyChanged("ComplexList");
            }
        }

        private ObservableCollection<House> _houseList;
        public ObservableCollection<House> HouseList
        {
            get => _houseList;
            set
            {
                _houseList = value;
                OnPropertyChanged("HouseList");
            }
        }

        

        private ObservableCollection<string> _cityList;
        public ObservableCollection<string> CityList
        {
            get => _cityList;
            set
            {
                _cityList = value;
                OnPropertyChanged("CityList");
            }
        }
        private ObservableCollection<string> _statusList;
        public ObservableCollection<string> StatusList
        {
            get => _statusList;
            set
            {
                _statusList = value;
                OnPropertyChanged("StatusList");
            }
        }



        private string _selectedStatus;
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                if (!string.IsNullOrEmpty(_selectedStatus))
                {
                    FilteredComplexList =
                        new ObservableCollection<ComplexWithHouses>(
                            from item
                                in ComplexList
                            where (item.StatusConstructionHousingComplexName.ToUpper().Contains(_selectedStatus.ToUpper()))
                            select item);
                    if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
                }

                OnPropertyChanged("SelectedStatus");
            }
        }
        private string _selectedCity;
        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                if (!string.IsNullOrEmpty(_selectedCity))
                {
                    FilteredComplexList =
                        new ObservableCollection<ComplexWithHouses>(
                            from item
                                in ComplexList
                            where (item.City.ToUpper().Contains(_selectedCity.ToUpper()))
                            select item);
                    if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
                }

                OnPropertyChanged("SelectedCity");

            }
        }




        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                FilteredComplexList =
                    new ObservableCollection<ComplexWithHouses>(
                        from item
                            in ComplexList
                        where (item.NameHousingComplex.ToUpper().Contains(SearchText.ToUpper())
                               || item.City.ToUpper().Contains(SearchText.ToUpper())
                               || item.StatusConstructionHousingComplexName.ToUpper().Contains(SearchText.ToUpper()))
                        select item);
                if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
                OnPropertyChanged("SearchText");
            }
        }

        private Complex selectedRow;
        public Complex SelectedRow
        {
            get => selectedRow;
            set
            {
                selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }


        public RelayCommand SaveCommand { get; }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(Message);
            }
        }
        

        public RelayCommand DeleteCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

        private void LoadData()
        {
            ComplexList = new ObservableCollection<ComplexWithHouses>(DataController.GetAllComplexWithHouses());
            HouseList = new ObservableCollection<House>(DataController.GetAllHouse());
            
            foreach (var complex in ComplexList)
            {
                complex.HouseCount = HouseList.Count(x => x.IdComplex.Equals(complex.IdComplex));
                
            }
            StatusList = new ObservableCollection<string>(ComplexList.Select(c => c.StatusConstructionHousingComplexName).Distinct().ToList());
            CityList = new ObservableCollection<string>(ComplexList.Select(c => c.City).Distinct().ToList());
            SelectedRow = new Complex();
            SearchText = String.Empty;
            

        }


        public void Save(object param)
        {
            //var isAllSaved = true;
            //foreach (var item in filteredJournalList)
            //    if (!JournalController.Update(item))
            //        isAllSaved = false;

            //Message = isAllSaved ? "Изменения сохранены" : "При сохранении произошла ошибка";
            //MessageBox.Show(Message);
            //LoadData();
        }

        public void Delete(object param)
        {
            MessageBoxResult result = MessageBox.Show("Удалить?", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var isDeleted = DataController.Delete(SelectedRow);
                Message = isDeleted ? "Удалено" : "При удалении произошла ошибка";
                MessageBox.Show(Message);
                LoadData();
            }
            

        }
    }
}