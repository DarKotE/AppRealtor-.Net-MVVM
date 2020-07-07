using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.Apartment;
using Esoft.Util.Commands;
using Esoft.Util.Constants;
using Esoft.Util.Paginators;
using Esoft.Util.Searchers;

namespace Esoft.ViewModels
{
    public class ThirdVM : INotifyPropertyChanged
    {
        private const int ITEMSPERPAGEVAL = Const.ApartmentsVm.DefaultItemsPerPage;
        private const int MAXDISTANCE = Const.ApartmentsVm.DefaultLevenshteinDistance;

        private readonly ApartmentAdapter _apartmentAdapter;

        public ThirdVM()
        {
            _apartmentAdapter = new ApartmentAdapter();
            
            EditCommand = new RelayCommand(Edit);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete);
            NextPageCommand = new RelayCommand(NextPage);
            PrevPageCommand = new RelayCommand(PrevPage);
            LastPageCommand = new RelayCommand(LastPage);
            FirstPageCommand = new RelayCommand(FirstPage);
            CancelSelectionCommand = new RelayCommand(Cancel);
            LoadData();
        }
        
        private void LoadData()
        {
            ApartmentList = new ObservableCollection<ApartmentWithComplexes>(
                _apartmentAdapter.GetAllApartmentWithComplexes());
            FillFilterLists();
            SelectedRow = new ApartmentWithComplexes();
            SearchText = string.Empty;
        }

        private void FillFilterLists()
        {
            StatusList = new ObservableCollection<string>(
                ApartmentList.Select(c => c.StatusSaleName)
                    .Distinct()
                    .ToList());
            HouseAddressList = new ObservableCollection<string>(
                ApartmentList.Select(c => c.HouseAddress)
                    .Distinct()
                    .ToList());
            FloorList = new ObservableCollection<int>(
                ApartmentList.Select(c => c.Floor)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList());
            PorchList = new ObservableCollection<int>(
                ApartmentList.Select(c => c.Porch)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList());
            ComplexList = new ObservableCollection<string>(
                ApartmentList.Select(c => c.NameHousingComplex)
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList());
        }

        public ApartmentWithComplexes SelectedRow { get; set; }

        public ObservableCollection<string> ComplexList { get; set; }
        public ObservableCollection<string> StatusList { get; set; }
        public ObservableCollection<string> HouseAddressList { get; set; }
        public ObservableCollection<int> PorchList { get; set; }
        public ObservableCollection<int> FloorList { get; set; }

        private ObservableCollection<ApartmentWithComplexes> ApartmentList { get; set; }
        public ObservableCollection<ApartmentWithComplexes> FilteredApartmentList { get; set; }


        private PagingCollectionView _pagingApartmentListView;
        public PagingCollectionView PagingApartmentListView
        {
            get { return _pagingApartmentListView; }
            set
            {
                _pagingApartmentListView = value;
                OnPropertyChanged(nameof(PagingApartmentListView)); 
            }

        }

        private void FilterBySelection()
        {
            FilteredApartmentList =
                new ObservableCollection<ApartmentWithComplexes>(
                    ApartmentList.Where(item =>
                        (String.IsNullOrEmpty(SelectedStatus)
                         || item.StatusSaleName.ToUpper().Contains(SelectedStatus.ToUpper()))
                        &&
                        (String.IsNullOrEmpty(SelectedComplex)
                         || item.NameHousingComplex.ToUpper().Contains(SelectedComplex.ToUpper()))
                        &&
                        (String.IsNullOrEmpty(SelectedHouseAddress)
                         || item.HouseAddress.ToUpper().Contains(SelectedHouseAddress.ToUpper()))
                        &&
                        (SelectedFloor.Equals(default)
                         || item.Floor.Equals(SelectedFloor))
                        &&
                        (SelectedPorch.Equals(default)
                         || item.Porch.Equals(SelectedPorch))));
            PagingApartmentListView = new PagingCollectionView(FilteredApartmentList, ITEMSPERPAGEVAL);
            if (FilteredApartmentList.Any())
                SelectedRow = FilteredApartmentList[0];

        }


        private string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                _selectedStatus = value;
                FilterBySelection();
            }
        }

        private string _selectedComplex;
        public string SelectedComplex
        {
            get { return _selectedComplex; }
            set
            {
                _selectedComplex = value;
                FilterBySelection();
            }
        }

        private string _selectedHouseAddress;
        public string SelectedHouseAddress
        {
            get { return _selectedHouseAddress; }
            set
            {
                _selectedHouseAddress = value;
                FilterBySelection();
            }
        }

        private int? _selectedPorch;
        public int? SelectedPorch
        {
            get { return _selectedPorch; }
            set
            {
                _selectedPorch = value;
                FilterBySelection();
            }
        }

        private int? _selectedFloor = 0;
        public int? SelectedFloor
        {
            get { return _selectedFloor; }
            set
            {
                _selectedFloor = value;
                FilterBySelection();
            }
        }


        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                FilteredApartmentList =
                    new ObservableCollection<ApartmentWithComplexes>(
                        ApartmentList.Where(item =>
                        (String.IsNullOrWhiteSpace(SearchText)
                         ||
                         (Levenshtein.Distance(item.NameHousingComplex
                              .ToUpper(), SearchText.ToUpper()
                              .Trim()) < MAXDISTANCE 
                          ||
                          Levenshtein.Distance(item.FullAddress
                              .ToUpper(), SearchText.ToUpper()
                              .Trim()) < MAXDISTANCE))));

                if (FilteredApartmentList.Any()) SelectedRow = FilteredApartmentList[0];

                PagingApartmentListView = new PagingCollectionView(FilteredApartmentList, ITEMSPERPAGEVAL);

                OnPropertyChanged(nameof(SearchText));
            }
        }


        public string Message { get; set; }



        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand PrevPageCommand { get; }
        public RelayCommand NextPageCommand { get; }
        public RelayCommand LastPageCommand { get; }
        public RelayCommand FirstPageCommand { get; }
        public RelayCommand CancelSelectionCommand { get; }


        public void Add(object param)
        {
            App.CurrentItemId = 0;
        }

        public void Edit(object param)
        {
            App.CurrentItemId = SelectedRow.Id;
        }

        public void Cancel(object param)
        {
            LoadData();
        }

        public void NextPage(object param)
        {
            PagingApartmentListView.MoveToNextPage();
        }

        public void PrevPage(object param)
        {
            PagingApartmentListView.MoveToPreviousPage();
        }
        public void LastPage(object param)
        {
            PagingApartmentListView.MoveToLastPage();
        }
        public void FirstPage(object param)
        {
            PagingApartmentListView.MoveToFirstPage();
        }

        public void Delete(object param)
        {
            var result = MessageBox.Show("Удалить?",
                "Информация",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var isDeleted = _apartmentAdapter.DeleteApartment(SelectedRow);
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