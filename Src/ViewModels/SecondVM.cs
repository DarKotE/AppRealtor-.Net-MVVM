using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.Complex;
using Esoft.Util.Commands;

namespace Esoft.ViewModels
{
    public class SecondVM : INotifyPropertyChanged
    {
        
        private readonly ComplexAdapter _complexAdapter;

        public SecondVM()
        {
            _complexAdapter = new ComplexAdapter();

            EditCommand = new RelayCommand(Edit);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            
            LoadData();
        }

        private void LoadData()
        {
            ComplexList = new ObservableCollection<ComplexWithHouses>(
                _complexAdapter.GetAllComplexWithHousesSorted());

            StatusList = new ObservableCollection<string>(
                    ComplexList.Select(c => c.StatusConstructionHousingComplexName)
                    .Distinct()
                    .ToList());
            CityList = new ObservableCollection<string>(
                ComplexList.Select(c => c.City)
                .Distinct()
                .ToList());

            SelectedRow = new Complex();
            SearchText = String.Empty;
        }
        

        public ObservableCollection<string> CityList { get; set; }

        public ObservableCollection<string> StatusList { get; set; }

        public ObservableCollection<ComplexWithHouses> ComplexList { get; set; }


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

        public Complex SelectedRow { get; set; }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                FilterBySelection();
            }
        }

        private string _selectedCity;
        public string SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                FilterBySelection();
            }
        }

        private void FilterBySelection() 
        {
            FilteredComplexList =
                new ObservableCollection<ComplexWithHouses>(
                    ComplexList.Where(item =>
                        (String.IsNullOrEmpty(SelectedCity)
                         || item.City.ToUpper().Contains(SelectedCity.ToUpper())) 
                         &&
                         (String.IsNullOrEmpty(SelectedStatus) 
                          || item.StatusConstructionHousingComplexName
                              .ToUpper()
                              .Contains(SelectedStatus.ToUpper()))));
            if (FilteredComplexList.Any())
                SelectedRow = FilteredComplexList[0];
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
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

        public string Message { get; set; }

        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand AddCommand { get; }
        
        
        public void Add(object param)
        {
            App.CurrentItemId = 0;
        }


        public void Edit(object param)
        {
            App.CurrentItemId = SelectedRow.IdComplex;
        }

        public void Delete(object param)
        {
            var result = MessageBox.Show("Удалить?",
                "Информация",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var isDeleted = _complexAdapter.DeleteComplex(SelectedRow);
                Message = isDeleted
                    ? "Удалено"
                    : "При удалении произошла ошибка";
                MessageBox.Show(Message);
                LoadData();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}