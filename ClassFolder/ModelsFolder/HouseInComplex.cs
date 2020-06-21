using System.ComponentModel;

namespace Esoft.ClassFolder.ModelsFolder
{
    //properties for easy binding to view via viewmodel
    public class HouseInComplex :House, INotifyPropertyChanged
    {
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
            get { return _statusConstructionHousingComplex; }
            set { _statusConstructionHousingComplex = value;
                switch (_statusConstructionHousingComplex)
                {
                    case "1":
                        _statusConstructionHousingComplex = "План";
                        break;
                    case "2":
                        _statusConstructionHousingComplex = "Строительство";
                        break;
                    case "3":
                        _statusConstructionHousingComplex = "Реализация";
                        break;

                }
                OnPropertyChanged("StatusConstructionHousingComplex"); }
        }


        //properties don't exist in database
        private int _soldApartmentCount;
        public int SoldApartmentCount
        {
            get { return _soldApartmentCount; }
            set
            {
                _soldApartmentCount = value;
                OnPropertyChanged("SoldApartmentCount");
            }
        }
        private int _readyApartmentCount;
        public int ReadyApartmentCount
        {
            get { return _readyApartmentCount; }
            set
            {
                _readyApartmentCount = value;
                OnPropertyChanged("ReadyApartmentCount");
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
