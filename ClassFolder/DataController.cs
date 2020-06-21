using System.Collections.Generic;

namespace Esoft.ClassFolder
{
    public class DataController
    {
        public SqlMethods DataAccess { get; }


        public DataController()
        {
            DataAccess = new SqlMethods();
        }

        #region RetrieveTables
        public List<Complex> GetAllComplex()
        {
            var complexList = DataAccess.SelectAllComplex();
            return complexList ?? new List<Complex>();
        }

        public List<House> GetAllHouse()
        {
            var houseList = DataAccess.SelectAllHouse();
            return houseList ?? new List<House>();
        }

        public List<Apartment> GetAllApartment()
        {
            var apartmentList = DataAccess.SelectAllApartment();
            return apartmentList ?? new List<Apartment>();
        }

        public List<HouseInComplex> GetAllHouseInComplex()
        {
            var houseList = DataAccess.SelectAllHouseInComplex();
            return houseList ?? new List<HouseInComplex>();
        }
        #endregion


        #region CRUD operations for Complex 
        public bool Create(Complex newComplex)
        {
            return DataAccess != null && DataAccess.InsertComplex(newComplex);
        }

        public bool Read(Complex selectComplex)
        {
            return DataAccess != null && DataAccess.SelectComplex(selectComplex);
        }

        public bool Update(Complex updateComplex)
        {
            return DataAccess != null && DataAccess.UpdateComplex(updateComplex);
        }

        public bool Delete(Complex deleteComplex)
        {
            return DataAccess != null && DataAccess.DeleteComplex(deleteComplex);
        }

        #endregion

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


        #region CRUD operations for House

        public bool Create(House newHouse)
        {
            return DataAccess != null && DataAccess.InsertHouse(newHouse);
        }

        public bool Read(House selectHouse)
        {
            return DataAccess != null && DataAccess.SelectHouse(selectHouse);
        }

        public bool Update(House updateHouse)
        {
            return DataAccess != null && DataAccess.UpdateHouse(updateHouse);
        }

        public bool Delete(House deleteHouse)
        {
            return DataAccess != null && DataAccess.DeleteHouse(deleteHouse);
        }

        #endregion

        #region CRUD operations for HouseInComplex

        public bool Create(HouseInComplex newHouse)
        {
            return DataAccess != null && DataAccess.InsertHouse(newHouse);
        }

        public bool Read(HouseInComplex selectHouse)
        {
            return DataAccess != null && DataAccess.SelectHouse(selectHouse);
        }

        public bool Update(HouseInComplex updateHouse)
        {
            return DataAccess != null && DataAccess.UpdateHouse(updateHouse);
        }

        public bool Delete(HouseInComplex deleteHouse)
        {
            return DataAccess != null && DataAccess.DeleteHouse(deleteHouse);
        }

        #endregion




    }
}