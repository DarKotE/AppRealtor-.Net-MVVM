using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.House;
using Esoft.Util.Commands;

namespace Esoft.ViewModels

{
    public class MainVM : INotifyPropertyChanged
    {
        private readonly HouseAdapter _houseAdapter;

        public MainVM()
        {
            _houseAdapter = new HouseAdapter();

            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);

            LoadData();
        }

        private void LoadData()
        {
            HouseList = new ObservableCollection<HouseInComplex>(_houseAdapter.GetAllHouseInComplexSorted());

            ComplexList = new ObservableCollection<string>(
                HouseList.Select(c => c.NameHousingComplex)
                    .Distinct()
                    .ToList());
            StreetList = new ObservableCollection<string>(
                HouseList.Select(c => c.Street)
                    .Distinct()
                    .ToList());
            SelectedRow = new House();
            SearchText = String.Empty;
        }


        public ObservableCollection<string> ComplexList { get; set; }

        public ObservableCollection<string> StreetList { get; set; }
       
        public ObservableCollection<HouseInComplex> HouseList { get; set; }
        

        private ObservableCollection<HouseInComplex> _filteredHouseList;
        public ObservableCollection<HouseInComplex> FilteredHouseList
        {
            get => _filteredHouseList;
            set
            {
                _filteredHouseList = value;
                OnPropertyChanged(nameof(FilteredHouseList));
            }
        }
        

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                FilteredHouseList =
                    new ObservableCollection<HouseInComplex>(
                        from item
                            in HouseList
                        where (item.NameHousingComplex.ToUpper().Contains(SearchText.ToUpper())
                               || item.Street.ToUpper().Contains(SearchText.ToUpper()))
                        select item);
                if (FilteredHouseList.Any()) SelectedRow = FilteredHouseList[0];
                OnPropertyChanged(nameof(SearchText));
            }
        }
        

        public string Message { get; set; }

        private string _selectedComplex;
        public string SelectedComplex
        {
            get => _selectedComplex;
            set
            {
                _selectedComplex = value;
                FilterBySelection();
            }
        }


        private string _selectedStreet;
        public string SelectedStreet
        {
            get => _selectedStreet;
            set
            {
                _selectedStreet = value;
                FilterBySelection();
            }
        }

        private void FilterBySelection()
        {
            FilteredHouseList =
                new ObservableCollection<HouseInComplex>(
                    HouseList.Where(item =>
                        (String.IsNullOrEmpty(SelectedStreet)
                         || (item.Street.ToUpper().Contains(SelectedStreet.ToUpper())))
                         && 
                        (String.IsNullOrEmpty(SelectedComplex) 
                          || (item.NameHousingComplex.ToUpper().Contains(SelectedComplex.ToUpper())))));
            if (FilteredHouseList.Any()) SelectedRow = FilteredHouseList[0];

        }


        public House SelectedRow { get; set; }


        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand AddCommand { get; }


        public void Add(object param)
        {
            App.Id = default;
        }


        public void Edit(object param)
        {
            App.Id = SelectedRow.IdHouse;
        }


        public void Delete(object param)
        {
            MessageBoxResult result = MessageBox.Show("Удалить?",
                "Информация",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var isDeleted = _houseAdapter.DeleteHouse(SelectedRow);
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