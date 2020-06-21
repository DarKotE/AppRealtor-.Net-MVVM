using System.ComponentModel;

namespace Esoft.ClassFolder.ModelsFolder
{
    public class Complex : INotifyPropertyChanged
    {
        private int _idComplex;
        public int IdComplex
        {
            get { return _idComplex; }
            set { _idComplex = value; OnPropertyChanged("IdComplex"); }
        }


        private string _nameHousingComplex;
        public string NameHousingComplex
        {
            get { return _nameHousingComplex; }
            set { _nameHousingComplex = value; OnPropertyChanged("NameHousingComplex"); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged("City"); }
        }

        private string _statusConstructionHousingComplex;
        public string StatusConstructionHousingComplex
        {
            get
            {
                return _statusConstructionHousingComplex;
            }
            set { _statusConstructionHousingComplex = value;
                OnPropertyChanged("StatusConstructionHousingComplex"); }
        }

        private long _addedValue;
        public long AddedValue
        {
            get { return _addedValue; }
            set { _addedValue = value; OnPropertyChanged("AddedValue"); }
        }

        private long _buildingCost;

        public long BuildingCost
        {
            get { return _buildingCost; }
            set
            {
                _buildingCost = value;
                OnPropertyChanged("BuildingCost");
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
