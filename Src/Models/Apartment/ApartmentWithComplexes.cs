using System.ComponentModel;
using Esoft.Util.Constants;

namespace Esoft.Models.Apartment
{

    public class ApartmentWithComplexes: Apartment, INotifyPropertyChanged
    {

        private string _nameHousingComplex;
        public string NameHousingComplex
        {
            get { return _nameHousingComplex; }
            set { _nameHousingComplex = value; 
                OnPropertyChanged(nameof(NameHousingComplex)); }
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


        private string _fullAddress;
        public string FullAddress
        {
            get
            {
                _fullAddress = "ул.";
                _fullAddress += Street;
                _fullAddress += " д.";
                _fullAddress += NumberHouse;
                _fullAddress += " кв.";
                _fullAddress += NumberApartment.ToString();
                return _fullAddress;
            }
            set
            {
                _fullAddress = value;
                OnPropertyChanged(nameof(FullAddress));
            }
        }

        private string _statusSaleName;
        public string StatusSaleName
        {
            get
            {
                switch (StatusSale)
                {
                    case Const.StatusApartmentValue.Sold:
                        _statusSaleName = "продана";
                        break;

                    case Const.StatusApartmentValue.Ready:
                        _statusSaleName = "продаётся";
                        break;

                }
                return _statusSaleName;
            }
            set
            {
                _statusSaleName = value;
                
                OnPropertyChanged(nameof(StatusSaleName));
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




