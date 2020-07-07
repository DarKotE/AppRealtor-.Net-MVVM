using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Esoft.DataAccess.DataSqlGateways;
using Esoft.Models.Complex;
using Esoft.Models.House;

namespace Esoft.DataAccess.DataAdapters
{
    public class ComplexAdapter
    {
        public ComplexSqlGateway ComplexAccess { get; }
        public HouseSqlGateway HouseAccess { get; }


        public ComplexAdapter()
        {
            ComplexAccess = new ComplexSqlGateway();
            HouseAccess = new HouseSqlGateway();
        }

        public List<Complex> GetAllComplex()
        {
            List<Complex> complexList = ComplexAccess.SelectAllComplex();
            return complexList ?? new List<Complex>();
        }

        public List<ComplexWithHouses> GetAllComplexWithHouses()
        {
            List<ComplexWithHouses> complexList = ComplexAccess.SelectAllComplexWithHouses();
            return complexList ?? new List<ComplexWithHouses>();
        }
        public List<ComplexWithHouses> GetAllComplexWithHousesSorted()
        {
            List<ComplexWithHouses> complexListSorted = ComplexAccess.SelectAllComplexWithHouses()
                .OrderBy(s => s.City)
                .ThenBy(s => s.StatusConstructionHousingComplexName)
                .ToList();

            var houseList = new ObservableCollection<House>(HouseAccess.SelectAllHouse());

            foreach (var complex in complexListSorted)
            {
                int count = houseList.Count(x => x.IdComplex.Equals(complex.IdComplex));

                complex.HouseCount = count;
            }

            return complexListSorted ?? new List<ComplexWithHouses>();
        }

        public bool IsDeleteAvailable(Complex newComplex)
        {
            return ComplexAccess != null && ComplexAccess.IsDeleteComplexPossible(newComplex);
        }
        public bool IsPlanAvailable(Complex newComplex)
        {
            return ComplexAccess != null && ComplexAccess.IsDeleteComplexPossible(newComplex);
        }


        public bool AddComplex(Complex newComplex)
        {
            return ComplexAccess != null && ComplexAccess.InsertComplex(newComplex);
        }

        public Complex GetComplex(Complex selectComplex)
        {
            if (ComplexAccess != null) return ComplexAccess.SelectComplex(selectComplex);
            return new Complex();
        }

        public ComplexWithHouses GetComplexWithHouses(Complex selectComplex)
        {
            if (ComplexAccess != null)
            {
                Complex temp = ComplexAccess.SelectComplex(selectComplex);
                var downCastedComplex = new ComplexWithHouses
                {
                    AddedValue = temp.AddedValue,
                    BuildingCost = temp.BuildingCost,
                    City = temp.City,
                    IdComplex = temp.IdComplex,
                    IsDeleted = temp.IsDeleted,
                    StatusConstructionHousingComplex = temp.StatusConstructionHousingComplex,
                    NameHousingComplex = temp.NameHousingComplex
                };
                
                return downCastedComplex;
            }
                
            return new ComplexWithHouses();
        }

        public bool SetComplex(Complex updateComplex)
        {
            return ComplexAccess != null && ComplexAccess.UpdateComplex(updateComplex);
        }

        public bool DeleteComplex(Complex deleteComplex)
        {
            return deleteComplex != null 
                   && HouseAccess != null
                   && ComplexAccess != null
                   && HouseAccess.DeleteHouseByComplexId(deleteComplex.IdComplex)
                   && ComplexAccess.DeleteComplex(deleteComplex);
        }

        

    }
}
