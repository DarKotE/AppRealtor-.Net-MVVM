using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.ClassFolder;
using Esoft.CommandsFolder;

namespace Esoft.ViewModelsFolder

{
    public class MainVM : INotifyPropertyChanged
    {

        private string message;
        private string searchText;


        public MainVM()
        {
            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);
            DataController = new DataController();
            LoadData();
        }

        public RelayCommand EditCommand { get; set; }

        public DataController DataController { get; }

        private ObservableCollection<HouseInComplex> _filteredHouseList;
        public ObservableCollection<HouseInComplex> FilteredHouseList
        {
            get => _filteredHouseList;
            set
            {
                _filteredHouseList = value;
                OnPropertyChanged("FilteredHouseList");
            }
        }


        private ObservableCollection<HouseInComplex> _houseList;
        public ObservableCollection<HouseInComplex> HouseList
        {
            get => _houseList;
            set
            {
                _houseList = value;
                OnPropertyChanged("HouseList");
            }
        }
        private ObservableCollection<Apartment> _apartmentList;
        public ObservableCollection<Apartment> ApartmentList
        {
            get => _apartmentList;
            set
            {
                _apartmentList = value;
                OnPropertyChanged("ApartmentList");
            }
        }

        private ObservableCollection<string> _complexList;
        public ObservableCollection<string> ComplexList
        {
            get => _complexList;
            set
            {
                _complexList = value;
                OnPropertyChanged("ComplexList");
            }
        }

        private ObservableCollection<string> _streetList;
        public ObservableCollection<string> StreetList
        {
            get => _streetList;
            set
            {
                _streetList = value;
                OnPropertyChanged("StreetList");
            }
        }
        

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                FilteredHouseList =
                    new ObservableCollection<HouseInComplex>(
                        from item
                            in HouseList
                        where (item.NameHousingComplex.ToUpper().Contains(SearchText.ToUpper())
                               || item.Street.ToUpper().Contains(SearchText.ToUpper()))
                        select item);
                if (FilteredHouseList.Any()) SelectedRow = FilteredHouseList[0];
                OnPropertyChanged("SearchText");
            }
        }

        private House selectedRow;
        public House SelectedRow
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
                   
                OnPropertyChanged("SelectedComplex");
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
                
                OnPropertyChanged("SelectedStreet");                

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
            HouseList = new ObservableCollection<HouseInComplex>(DataController.GetAllHouseInComplex());
            ApartmentList = new ObservableCollection<Apartment>(DataController.GetAllApartment());
            foreach (var house in HouseList)
            {
                house.ReadyApartmentCount =
                    ApartmentList.Count(x => x.IdLsd.Equals(house.IdHouse) && x.StatusSale.Equals("ready"));
                house.SoldApartmentCount =
                    ApartmentList.Count(x => x.IdLsd.Equals(house.IdHouse) && x.StatusSale.Equals("sold"));
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
                var isDeleted = DataController.Delete(SelectedRow);
                Message = isDeleted
                    ? "Удалено"
                    : "При удалении произошла ошибка";
                MessageBox.Show(Message);
                LoadData();
            }
            

        }
    }
}