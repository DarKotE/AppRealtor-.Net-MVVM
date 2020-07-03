using System.ComponentModel;

namespace Esoft.Classes.Models.Complex
{
    //for easy binding to view via viewmodel
    public class ComplexWithHouses : Complex, INotifyPropertyChanged
    {
        //for viewmodel
        private string _statusConstructionHousingComplexName;
        public string StatusConstructionHousingComplexName
        {
            get { return _statusConstructionHousingComplexName; }
            set
            {
                _statusConstructionHousingComplexName = value;
                switch (_statusConstructionHousingComplexName)
                {
                    case Const.StatusConstructionValue.Plan:
                        _statusConstructionHousingComplexName = "План";
                        break;

                    case Const.StatusConstructionValue.Build:
                        _statusConstructionHousingComplexName = "Строительство";
                        break;
                    
                    case Const.StatusConstructionValue.Sell:
                        _statusConstructionHousingComplexName = "Реализация";
                        break;

                }
                OnPropertyChanged(nameof(StatusConstructionHousingComplexName));
            }
        }



        private int _houseCount;
        public int HouseCount
        {
            get { return _houseCount; }
            set
            {
                _houseCount = value;
                OnPropertyChanged(nameof(HouseCount));
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));

        }
    }
}
