using System.Collections.Generic;
using Esoft.Classes.DataSqlGateways;
using Esoft.Classes.Models.Apartment;

namespace Esoft.Classes.DataAdapters
{
    public class ApartmentAdapter
    {
        public ApartmentSqlGateway DataAccess { get; }
        
        public ApartmentAdapter()
        {
            DataAccess = new ApartmentSqlGateway();
        }
        
        public List<Apartment> GetAllApartment()
        {
            var apartmentList = DataAccess.SelectAllApartment();
            return apartmentList ?? new List<Apartment>();
        }

        #region CRUD operations for Apartment

        public bool Create(Apartment newApartment)
        {
            return DataAccess != null && DataAccess.InsertApartment(newApartment);
        }

        public bool Read(Apartment selectApartment)
        {
            return DataAccess != null && DataAccess.SelectApartment(selectApartment);
        }

        public bool Update(Apartment updateApartment)
        {
            return DataAccess != null && DataAccess.UpdateApartment(updateApartment);
        }

        public bool Delete(Apartment deleteApartment)
        {
            return DataAccess != null && DataAccess.DeleteApartment(deleteApartment);
        }
        #endregion

    }
}
