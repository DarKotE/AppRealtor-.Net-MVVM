using System.ComponentModel;
using Esoft.Util.Constants;

namespace Esoft.Models.House
{
    //properties for easy binding to view via viewmodel
    public class HouseInComplex :House, INotifyPropertyChanged
    {
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
            get { return _statusConstructionHousingComplex; }
            set { _statusConstructionHousingComplex = value;
                switch (_statusConstructionHousingComplex)
                {
                    case Const.StatusConstructionValue.Plan:
                        _statusConstructionHousingComplex = "План";
                        break;
                    case Const.StatusConstructionValue.Build:
                        _statusConstructionHousingComplex = "Строительство";
                        break;
                    case Const.StatusConstructionValue.Sell:
                        _statusConstructionHousingComplex = "Реализация";
                        break;

                }
                OnPropertyChanged(nameof(StatusConstructionHousingComplex)); }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));

        }
    }
}
