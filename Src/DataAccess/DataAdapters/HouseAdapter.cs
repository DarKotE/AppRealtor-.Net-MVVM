using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Esoft.DataAccess.DataSqlGateways;
using Esoft.Models.Apartment;
using Esoft.Models.House;
using Esoft.Util.Constants;

namespace Esoft.DataAccess.DataAdapters
{
    public class HouseAdapter
    {
        public HouseSqlGateway HouseAccess { get; }

        public ApartmentSqlGateway ApartmentDataAccess { get; }

        public HouseAdapter()
        {
            HouseAccess = new HouseSqlGateway();
            ApartmentDataAccess = new ApartmentSqlGateway();
        }

        public List<House> GetAllHouse()
        {
            var houseList = HouseAccess.SelectAllHouse();
            return houseList ?? new List<House>();
        }


        public List<HouseInComplex> GetAllHouseInComplex()
        {
            var houseList = HouseAccess.SelectAllHouseInComplex();
            return houseList ?? new List<HouseInComplex>();
        }
        public List<HouseInComplex> GetAllHouseInComplexSorted()
        {
            var houseListSorted = HouseAccess.SelectAllHouseInComplex()
                .OrderBy(s => s.NameHousingComplex)
                .ThenBy(s => s.Street)
                .ThenBy(s => s.NumberHouse)
                .ToList(); ;
            
            
            var apartmentList = new ObservableCollection<Apartment>(ApartmentDataAccess.SelectAllApartment());

            foreach (var house in houseListSorted)
            {
                int count = 0;
                foreach (var x in apartmentList)
                {
                    if (x.IdLsd.Equals(house.IdHouse) && x.StatusSale.Equals(Const.StatusApartmentValue.Ready))
                        count++;
                }

                house.ReadyApartmentCount = count;

                int count1 = 0;
                foreach (var x in apartmentList)
                {
                    if (x.IdLsd.Equals(house.IdHouse) && x.StatusSale.Equals(Const.StatusApartmentValue.Sold))
                        count1++;
                }
                house.SoldApartmentCount = count1;
            }
            return houseListSorted ?? new List<HouseInComplex>();
        }


        #region CRUD operations for House

        public bool AddHouse(House newHouse)
        {
            return HouseAccess != null && HouseAccess.InsertHouse(newHouse);
        }

        public House GetHouse(House selectHouse)
        {
            if (HouseAccess != null) return HouseAccess.SelectHouse(selectHouse);
            return new House();
        }

        public bool SetHouse(House updateHouse)
        {
            return HouseAccess != null && HouseAccess.UpdateHouse(updateHouse);
        }

        public bool DeleteHouse(House deleteHouse)
        {
            return HouseAccess != null && HouseAccess.DeleteHouse(deleteHouse);
        }
        public bool DeleteHouseByComplexId(int idComplex)
        {
            return HouseAccess != null && HouseAccess.DeleteHouseByComplexId(idComplex);
        }
        #endregion

    }
}
