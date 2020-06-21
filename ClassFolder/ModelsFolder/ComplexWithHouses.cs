using System.Collections;
using System.ComponentModel;
namespace Esoft.ClassFolder
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
                    case "1":
                        _statusConstructionHousingComplexName = "План";
                        break;

                    case "2":
                        _statusConstructionHousingComplexName = "Строительство";
                        break;
                    
                    case "3":
                        _statusConstructionHousingComplexName = "Реализация";
                        break;

                }
                OnPropertyChanged("StatusConstructionHousingComplexName");
            }
        }



        private int _houseCount;
        public int HouseCount
        {
            get { return _houseCount; }
            set
            {
                _houseCount = value;
                OnPropertyChanged("HouseCount");
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
