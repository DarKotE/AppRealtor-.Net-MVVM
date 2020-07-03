using System.Collections.Generic;
using Esoft.Classes.DataSqlGateways;
using Esoft.Classes.Models.House;


namespace Esoft.Classes.DataAdapters
{
    public class HouseAdapter
    {
        public HouseSqlGateway DataAccess { get; }

        public HouseAdapter()
        {
            DataAccess = new HouseSqlGateway();
        }

        public List<House> GetAllHouse()
        {
            var houseList = DataAccess.SelectAllHouse();
            return houseList ?? new List<House>();
        }


        public List<HouseInComplex> GetAllHouseInComplex()
        {
            var houseList = DataAccess.SelectAllHouseInComplex();
            return houseList ?? new List<HouseInComplex>();
        }

        #region CRUD operations for House

        public bool AddHouse(House newHouse)
        {
            return DataAccess != null && DataAccess.InsertHouse(newHouse);
        }

        public House GetHouse(House selectHouse)
        {
            if (DataAccess != null) return DataAccess.SelectHouse(selectHouse);
            return new House();
        }

        public bool SetHouse(House updateHouse)
        {
            return DataAccess != null && DataAccess.UpdateHouse(updateHouse);
        }

        public bool DeleteHouse(House deleteHouse)
        {
            return DataAccess != null && DataAccess.DeleteHouse(deleteHouse);
        }
        #endregion

    }
}
