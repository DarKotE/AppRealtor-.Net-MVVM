using System.Collections.Generic;
using Esoft.ClassFolder.ModelsFolder;

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
        public List<ComplexWithHouses> GetAllComplexWithHouses()
        {
            var houseList = DataAccess.SelectAllComplexWithHouses();
            return houseList ?? new List<ComplexWithHouses>();
        }
        #endregion


        #region CRUD operations for Complex 
        public bool CanDelete(Complex newComplex)
        {
            return DataAccess != null && DataAccess.CanDeleteComplex(newComplex);
        }
        public bool CanPlan(Complex newComplex)
        {
            return DataAccess != null && DataAccess.CanDeleteComplex(newComplex);
        }


        public bool Create(Complex newComplex)
        {
            return DataAccess != null && DataAccess.InsertComplex(newComplex);
        }

        public Complex Read(Complex selectComplex)
        {
            if (DataAccess != null) return DataAccess.SelectComplex(selectComplex);
            return new Complex();
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

        public House Read(House selectHouse)
        {
            if (DataAccess != null) return DataAccess.SelectHouse(selectHouse);
            return new House();

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


        #endregion




    }
}