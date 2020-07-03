using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.Classes;
using Esoft.Classes.Commands;
using Esoft.Classes.DataAdapters;
using Esoft.Classes.Models.Apartment;
using Esoft.Classes.Models.House;

namespace Esoft.ViewModels

{
    public class MainVM : INotifyPropertyChanged 
    {

        public MainVM()
        {
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            HouseAdapter = new HouseAdapter();
            ComplexAdapter = new ComplexAdapter();
            ApartmentAdapter = new ApartmentAdapter();
            LoadData();
        }

        public RelayCommand EditCommand { get; set; }

        public HouseAdapter HouseAdapter { get; }
        public ComplexAdapter ComplexAdapter { get; }
        public ApartmentAdapter ApartmentAdapter { get; }

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


        private ObservableCollection<HouseInComplex> _houseList;
        public ObservableCollection<HouseInComplex> HouseList
        {
            get => _houseList;
            set
            {
                _houseList = value;
                OnPropertyChanged(nameof(HouseList));
            }
        }
        private ObservableCollection<Apartment> _apartmentList;
        public ObservableCollection<Apartment> ApartmentList
        {
            get => _apartmentList;
            set
            {
                _apartmentList = value;
                OnPropertyChanged(nameof(ApartmentList));
            }
        }

        private ObservableCollection<string> _complexList;
        public ObservableCollection<string> ComplexList
        {
            get => _complexList;
            set
            {
                _complexList = value;
                OnPropertyChanged(nameof(ComplexList));
            }
        }

        private ObservableCollection<string> _streetList;
        public ObservableCollection<string> StreetList
        {
            get => _streetList;
            set
            {
                _streetList = value;
                OnPropertyChanged(nameof(StreetList));
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

        private House _selectedRow;
        public House SelectedRow
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


        private string _selectedComplex;
        public string SelectedComplex
        {
            get => _selectedComplex;
            set
            {
                _selectedComplex = value;
                if (!string.IsNullOrEmpty(_selectedComplex))
                {
                    FilteredHouseList =
                        new ObservableCollection<HouseInComplex>(
                            from item
                                in HouseList
                            where (item.NameHousingComplex.ToUpper().Contains(_selectedComplex.ToUpper()))
                            select item);
                    if (FilteredHouseList.Any()) SelectedRow = FilteredHouseList[0];
                }
                   
                OnPropertyChanged(nameof(SelectedComplex));
            }
        }
        private string _selectedStreet;
        public string SelectedStreet
        {
            get => _selectedStreet;
            set
            {
                _selectedStreet = value;
                if (!string.IsNullOrEmpty(_selectedStreet))
                {
                    FilteredHouseList =
                        new ObservableCollection<HouseInComplex>(
                            from item
                                in HouseList
                            where (item.Street.ToUpper().Contains(_selectedStreet.ToUpper()))
                            select item);
                    if (FilteredHouseList.Any()) SelectedRow = FilteredHouseList[0];
                }
                
                OnPropertyChanged(nameof(SelectedStreet));                

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
            HouseList = new ObservableCollection<HouseInComplex>(HouseAdapter.GetAllHouseInComplex());
            ApartmentList = new ObservableCollection<Apartment>(ApartmentAdapter.GetAllApartment());
            foreach (var house in HouseList)
            {
                int count = 0;
                foreach (var x in ApartmentList)
                {
                    if (x.IdLsd.Equals(house.IdHouse) && x.StatusSale.Equals(Const.StatusApartmentValue.Ready)) 
                        count++;
                }

                house.ReadyApartmentCount = count;

                int count1 = 0;
                foreach (var x in ApartmentList)
                {
                    if (x.IdLsd.Equals(house.IdHouse) && x.StatusSale.Equals(Const.StatusApartmentValue.Sold))
                        count1++;
                }

                house.SoldApartmentCount = count1;
            }

            ComplexList = new ObservableCollection<string>(HouseList.Select(c => c.NameHousingComplex)
                .Distinct()
                .ToList());
            StreetList = new ObservableCollection<string>(HouseList.Select(c => c.Street)
                .Distinct()
                .ToList());
            SelectedRow = new House();
            SearchText = String.Empty;


        }


        public void Add(object param)
        {

            App.Id = 0;


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
                var isDeleted = HouseAdapter.DeleteHouse(SelectedRow);
                Message = isDeleted
                    ? "Удалено"
                    : "При удалении произошла ошибка";
                MessageBox.Show(Message);
                LoadData();
            }
            

        }
    }
}