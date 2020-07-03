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

    }
}
