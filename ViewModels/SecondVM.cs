using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.Classes.Commands;
using Esoft.Classes.DataAdapters;
using Esoft.Classes.Models.Complex;
using Esoft.Classes.Models.House;

namespace Esoft.ViewModels

{
    public class SecondVM : INotifyPropertyChanged
    {
        public SecondVM()
        {
            EditCommand = new RelayCommand(Edit);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            HouseAdapter = new HouseAdapter();
            ComplexAdapter = new ComplexAdapter();
            LoadData();
        }

        public RelayCommand EditCommand { get; set; }

        public HouseAdapter HouseAdapter { get; }
        public ComplexAdapter ComplexAdapter { get; }

        private ObservableCollection<ComplexWithHouses> _filteredComplexList;

        public ObservableCollection<ComplexWithHouses> FilteredComplexList
        {
            get => _filteredComplexList;
            set
            {
                _filteredComplexList = value;
                OnPropertyChanged(nameof(FilteredComplexList));
            }
        }


        private ObservableCollection<ComplexWithHouses> _complexList;

        public ObservableCollection<ComplexWithHouses> ComplexList
        {
            get => _complexList;
            set
            {
                _complexList = value;
                OnPropertyChanged(nameof(ComplexList));
            }
        }

        private ObservableCollection<House> _houseList;

        public ObservableCollection<House> HouseList
        {
            get => _houseList;
            set
            {
                _houseList = value;
                OnPropertyChanged(nameof(HouseList));
            }
        }


        private ObservableCollection<string> _cityList;

        public ObservableCollection<string> CityList
        {
            get => _cityList;
            set
            {
                _cityList = value;
                OnPropertyChanged(nameof(CityList));
            }
        }

        private ObservableCollection<string> _statusList;

        public ObservableCollection<string> StatusList
        {
            get => _statusList;
            set
            {
                _statusList = value;
                OnPropertyChanged(nameof(StatusList));
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
                            where item.StatusConstructionHousingComplexName.ToUpper()
                                .Contains(_selectedStatus.ToUpper())
                            select item);
                    if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
                }

                OnPropertyChanged(nameof(SelectedStatus));
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
                            where item.City.ToUpper().Contains(_selectedCity.ToUpper())
                            select item);
                    if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
                }

                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                FilteredComplexList =
                    new ObservableCollection<ComplexWithHouses>(
                        from item
                            in ComplexList
                        where item.NameHousingComplex.ToUpper().Contains(SearchText.ToUpper())
                              || item.City.ToUpper().Contains(SearchText.ToUpper())
                              || item.StatusConstructionHousingComplexName.ToUpper().Contains(SearchText.ToUpper())
                        select item);
                if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
                OnPropertyChanged(nameof(SearchText));
            }
        }

        private Complex _selectedRow;

        public Complex SelectedRow
        {
            get => _selectedRow;
            set
            {
                _selectedRow = value;
                OnPropertyChanged(nameof(SelectedRow));
            }
        }


        public RelayCommand SaveCommand { get; }
        
        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(Message);
            }
        }


        public RelayCommand DeleteCommand { get; }
        public RelayCommand AddCommand { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void LoadData()
        {
            ComplexList = new ObservableCollection<ComplexWithHouses>(ComplexAdapter.GetAllComplexWithHouses());
            HouseList = new ObservableCollection<House>(HouseAdapter.GetAllHouse());

            foreach (var complex in ComplexList)
                complex.HouseCount = HouseList.Count(x => x.IdComplex.Equals(complex.IdComplex));
            StatusList =
                new ObservableCollection<string>(ComplexList.Select(c => c.StatusConstructionHousingComplexName)
                    .Distinct()
                    .ToList());
            CityList = new ObservableCollection<string>(ComplexList.Select(c => c.City)
                .Distinct()
                .ToList());
            SelectedRow = new Complex();
            SearchText = string.Empty;
        }


        public void Add(object param)
        {
            App.Id = 0;
        }


        public void Edit(object param)
        {
            App.Id = SelectedRow.IdComplex;
        }

        public void Delete(object param)
        {
            var result = MessageBox.Show("Удалить?",
                "Информация",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var isDeleted = ComplexAdapter.DeleteComplex(SelectedRow);
                Message = isDeleted
                    ? "Удалено"
                    : "При удалении произошла ошибка";
                MessageBox.Show(Message);
                LoadData();
            }
        }
    }
}