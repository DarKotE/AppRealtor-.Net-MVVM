using System.ComponentModel;

namespace Esoft.Models.Apartment
{

    public class Apartment : INotifyPropertyChanged
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private int _idLsd;

        public int IdLsd
        {
            get { return _idLsd; }
            set
            {
                _idLsd = value;
                OnPropertyChanged(nameof(IdLsd));
            }
        }


        private int _numberApartment;

        public int NumberApartment
        {
            get { return _numberApartment; }
            set
            {
                _numberApartment = value;
                OnPropertyChanged(nameof(NumberApartment));
            }
        }

        private double _area;

        public double Area
        {
            get { return _area; }
            set
            {
                _area = value;
                OnPropertyChanged(nameof(Area));
            }
        }

        private int _numberOfRooms;

        public int NumberOfRooms
        {
            get { return _numberOfRooms; }
            set
            {
                _numberOfRooms = value;
                OnPropertyChanged(nameof(NumberOfRooms));
            }
        }

        private int _porch;

        public int Porch
        {
            get { return _porch; }
            set
            {
                _porch = value;
                OnPropertyChanged(nameof(Porch));
            }
        }

        private int _floor;

        public int Floor
        {
            get { return _floor; }
            set
            {
                _floor = value;
                OnPropertyChanged(nameof(Floor));
            }
        }

        private string _statusSale;

        public string StatusSale
        {
            get { return _statusSale; }
            set
            {
                _statusSale = value;
                OnPropertyChanged(nameof(StatusSale));
            }
        }

        private long _addedValue;

        public long AddedValue
        {
            get { return _addedValue; }
            set
            {
                _addedValue = value;
                OnPropertyChanged(nameof(AddedValue));
            }
        }

        private long _expensesBuildingAnApartment;

        public long ExpensesBuildingAnApartament
        {
            get { return _expensesBuildingAnApartment; }
            set
            {
                _expensesBuildingAnApartment = value;
                OnPropertyChanged(nameof(ExpensesBuildingAnApartament));
            }
        }

        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                _isDeleted = value;
                OnPropertyChanged(nameof(IsDeleted));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));

        }
    }
}




