using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.Apartment;
using Esoft.Models.Complex;
using Esoft.Util.Commands;
using Esoft.Util.Paginators;

namespace Esoft.ViewModels
{
    public class ThirdVM : INotifyPropertyChanged
    {
        
        private readonly ComplexAdapter _complexAdapter;
        private readonly ApartmentAdapter _apartmentAdapter;

        private PagingCollectionView _cview;

        public PagingCollectionView Cview
        {
            get { return _cview; }
            set
            {
                _cview = value;
                OnPropertyChanged(nameof(FilteredComplexList)); ;
            }
            
        }

        public ThirdVM()
        {
            _complexAdapter = new ComplexAdapter();
            _apartmentAdapter = new ApartmentAdapter();
            
            EditCommand = new RelayCommand(Edit);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            NextPageCommand = new RelayCommand(NextPage);
            PrevPageCommand = new RelayCommand(PrevPage);

            LoadData();
            Cview = new PagingCollectionView(FilteredApartmentList,20);
            LoadData();
        }
        
        private void LoadData()
        {
            ApartmentList = new ObservableCollection<ApartmentWithComplexes>(_apartmentAdapter.GetAllApartmentWithComplexes());
            //ComplexList = new ObservableCollection<ComplexWithHouses>(_complexAdapter.GetAllComplexWithHousesSorted());
            //StatusList = new ObservableCollection<string>(
            //        ComplexList.Select(c => c.StatusConstructionHousingComplexName)
            //        .Distinct()
            //        .ToList());
            //CityList = new ObservableCollection<string>(
            //    ComplexList.Select(c => c.City)
            //    .Distinct()
            //    .ToList());
            SelectedRow = new ApartmentWithComplexes();
            SearchText = string.Empty;
        }
        

        public ObservableCollection<string> CityList { get; set; }

        public ObservableCollection<string> StatusList { get; set; }
        public ObservableCollection<ApartmentWithComplexes> ApartmentList { get; set; }
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
        private ObservableCollection<ApartmentWithComplexes> _filteredApartmentList;
        public ObservableCollection<ApartmentWithComplexes> FilteredApartmentList
        {
            get => _filteredApartmentList;
            set
            {
                _filteredApartmentList = value;
                OnPropertyChanged(nameof(FilteredApartmentList));
            }
        }

        public ApartmentWithComplexes SelectedRow { get; set; }

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
                            ComplexList.Where(item =>
                            item.StatusConstructionHousingComplexName.ToUpper().Contains(_selectedStatus.ToUpper())
                            && (String.IsNullOrEmpty(SelectedCity) 
                                || item.City.ToUpper().Contains(SelectedCity.ToUpper()))));
                    //if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
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
                        new ObservableCollection<ComplexWithHouses>(ComplexList.Where(item =>
                            item.City.ToUpper().Contains(_selectedCity.ToUpper())
                            && (String.IsNullOrEmpty(SelectedStatus) 
                                || item.StatusConstructionHousingComplexName.ToUpper().Contains(SelectedStatus.ToUpper()))));
                    //if (FilteredComplexList.Any()) SelectedRow = FilteredComplexList[0];
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
                FilteredApartmentList =
                    new ObservableCollection<ApartmentWithComplexes>(
                        from item
                            in ApartmentList
                        where item.NameHousingComplex.ToUpper().Contains(SearchText.ToUpper())
                              || item.FullAddress.ToUpper().Contains(SearchText.ToUpper())


                        select item);
                if (FilteredApartmentList.Any()) SelectedRow = FilteredApartmentList[0];
                OnPropertyChanged(nameof(SearchText));
            }
        }
        

        public string Message { get; set; }

        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand PrevPageCommand { get; }
        public RelayCommand NextPageCommand { get; }

        public void Add(object param)
        {
            App.Id = 0;
        }


        public void Edit(object param)
        {
            App.Id = SelectedRow.Id;
        }
        public void NextPage(object param)
        {
            Cview.MoveToNextPage();
        }
        public void PrevPage(object param)
        {
            Cview.MoveToPreviousPage();
        }

        public void Delete(object param)
        {
            var result = MessageBox.Show("Удалить?",
                "Информация",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //var isDeleted = _complexAdapter.DeleteComplex(SelectedRow);
                //Message = isDeleted
                //    ? "Удалено"
                //    : "При удалении произошла ошибка";
                //MessageBox.Show(Message);
                //LoadData();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}