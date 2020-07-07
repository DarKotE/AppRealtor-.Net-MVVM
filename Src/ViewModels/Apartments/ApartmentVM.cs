using System.Collections.Generic;
using Esoft.DataAccess.DataAdapters;
using Esoft.Models.Apartment;
using Esoft.Util.Commands;
using Esoft.Util.Validators;

namespace Esoft.ViewModels.Apartments
{
    public class ApartmentVM
    {
        //черновик 

        private string _message;
        private readonly ApartmentAdapter _apartmentAdapter; 

        public ApartmentVM()
        {
            _apartmentAdapter = new ApartmentAdapter();

            Validator = new Validator();

            SaveCommand = new RelayCommand(Save);
            AddCommand = new RelayCommand(Add);

            
            CurrentApartment = new Apartment();

            StatusList = new List<string> {"продана", "продаётся"};


            CurrentApartment.Id = App.CurrentItemId;
            CurrentApartment = _apartmentAdapter.GetApartment(CurrentApartment);

            

        }


        public Validator Validator { get; }


        public Apartment CurrentApartment { get; set; }

        public List<string> StatusList { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        
        
        public void Save(object param)
        {
            

        }

        public void Add(object param)
        {
           
        }
        
    }
}
