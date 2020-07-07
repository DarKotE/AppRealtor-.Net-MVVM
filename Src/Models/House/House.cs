using System.ComponentModel;

namespace Esoft.Models.House
{
    public class House : INotifyPropertyChanged
    {

        private int _idHouse;
        public int IdHouse
        {
            get { return _idHouse; }
            set
            {
                _idHouse = value;
                OnPropertyChanged(nameof(IdHouse));
            }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged(nameof(Street));
            }
        }

        private string _numberHouse;

        public string NumberHouse
        {
            get { return _numberHouse; }
            set
            {
                _numberHouse = value;
                OnPropertyChanged(nameof(NumberHouse));
            }
        }

        private long _costHouseConstruction;

        public long CostHouseConstruction
        {
            get { return _costHouseConstruction; }
            set
            {
                _costHouseConstruction = value;
                OnPropertyChanged(nameof(CostHouseConstruction));
            }
        }

        private long _additionalCostHouseConstruction;

        public long AdditionalCostHouseConstruction
        {
            get { return _additionalCostHouseConstruction; }
            set
            {
                _additionalCostHouseConstruction = value;
                OnPropertyChanged(nameof(AdditionalCostHouseConstruction));
            }
        }

        private int _idComplex;

        public int IdComplex
        {
            get { return _idComplex; }
            set
            {
                _idComplex = value;
                OnPropertyChanged(nameof(IdComplex));
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
