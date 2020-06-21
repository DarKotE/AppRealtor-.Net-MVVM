using System.ComponentModel;

namespace Esoft.ClassFolder.ModelsFolder
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
                OnPropertyChanged("Id");
            }
        }

        private int _idLsd;

        public int IdLsd
        {
            get { return _idLsd; }
            set
            {
                _idLsd = value;
                OnPropertyChanged("IdLsd");
            }
        }


        private int _numberApartment;

        public int NumberApartment
        {
            get { return _numberApartment; }
            set
            {
                _numberApartment = value;
                OnPropertyChanged("NumberApartment");
            }
        }

        private double _area;

        public double Area
        {
            get { return _area; }
            set
            {
                _area = value;
                OnPropertyChanged("Area");
            }
        }

        private int _numberOfRooms;

        public int NumberOfRooms
        {
            get { return _numberOfRooms; }
            set
            {
                _numberOfRooms = value;
                OnPropertyChanged("NumberOfRooms");
            }
        }

        private int _porch;

        public int Porch
        {
            get { return _porch; }
            set
            {
                _porch = value;
                OnPropertyChanged("Porch");
            }
        }

        private int _floor;

        public int Floor
        {
            get { return _floor; }
            set
            {
                _floor = value;
                OnPropertyChanged("Floor");
            }
        }

        private string _statusSale;

        public string StatusSale
        {
            get { return _statusSale; }
            set
            {
                _statusSale = value;
                OnPropertyChanged("StatusSale");
            }
        }

        private long _addedValue;

        public long AddedValue
        {
            get { return _addedValue; }
            set
            {
                _addedValue = value;
                OnPropertyChanged("AddedValue");
            }
        }

        private long _expensesBuildingAnApartment;

        public long ExpensesBuildingAnApartament
        {
            get { return _expensesBuildingAnApartment; }
            set
            {
                _expensesBuildingAnApartment = value;
                OnPropertyChanged("ExpensesBuildingAnApartment");
            }
        }

        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                _isDeleted = value;
                OnPropertyChanged("IsDeleted");
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




