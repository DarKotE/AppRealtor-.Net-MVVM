using System.ComponentModel;

namespace Esoft.Src.Models.Complex
{
    public class Complex : INotifyPropertyChanged
    {
        private int _idComplex;
        public int IdComplex
        {
            get { return _idComplex; }
            set { _idComplex = value; OnPropertyChanged(nameof(IdComplex)); }
        }


        private string _nameHousingComplex;
        public string NameHousingComplex
        {
            get { return _nameHousingComplex; }
            set { _nameHousingComplex = value; OnPropertyChanged(nameof(NameHousingComplex)); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged(nameof(City)); }
        }

        private string _statusConstructionHousingComplex;
        public string StatusConstructionHousingComplex
        {
            get
            {
                return _statusConstructionHousingComplex;
            }
            set { _statusConstructionHousingComplex = value;
                OnPropertyChanged(nameof(StatusConstructionHousingComplex)); }
        }

        private long _addedValue;
        public long AddedValue
        {
            get { return _addedValue; }
            set { _addedValue = value; OnPropertyChanged(nameof(AddedValue)); }
        }

        private long _buildingCost;

        public long BuildingCost
        {
            get { return _buildingCost; }
            set
            {
                _buildingCost = value;
                OnPropertyChanged(nameof(BuildingCost));
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
