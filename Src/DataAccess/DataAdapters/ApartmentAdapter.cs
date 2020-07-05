using System.Collections.Generic;
using Esoft.Src.DataAccess.DataSqlGateways;
using Esoft.Src.Models.Apartment;

namespace Esoft.Src.DataAccess.DataAdapters
{
    public class ApartmentAdapter
    {
        public ApartmentSqlGateway ApartmentAccess { get; }
        
        public ApartmentAdapter()
        {
            ApartmentAccess = new ApartmentSqlGateway();
        }
        
        public List<Apartment> GetAllApartment()
        {
            var apartmentList = ApartmentAccess.SelectAllApartment();
            return apartmentList ?? new List<Apartment>();
        }

        #region CRUD operations for Apartment

        public bool AddApartment(Apartment newApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.InsertApartment(newApartment);
        }

        public bool GetApartment(Apartment selectApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.SelectApartment(selectApartment);
        }

        public bool SetApartment(Apartment updateApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.UpdateApartment(updateApartment);
        }

        public bool DeleteApartment(Apartment deleteApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.DeleteApartment(deleteApartment);
        }
        #endregion

    }
}
