using System.Collections.Generic;
using Esoft.Classes.DataSqlGateways;
using Esoft.Classes.Models.Complex;

namespace Esoft.Classes.DataAdapters
{
    public class ComplexAdapter
    {
        public ComplexSqlGateway DataAccess { get; }
        
        public ComplexAdapter()
        {
            DataAccess = new ComplexSqlGateway();
        }

        public List<Complex> GetAllComplex()
        {
            var complexList = DataAccess.SelectAllComplex();
            return complexList ?? new List<Complex>();
        }

        public List<ComplexWithHouses> GetAllComplexWithHouses()
        {
            var houseList = DataAccess.SelectAllComplexWithHouses();
            return houseList ?? new List<ComplexWithHouses>();
        }

        #region CRUD operations for Complex 
        public bool IsDeleteAvailable(Complex newComplex)
        {
            return DataAccess != null && DataAccess.CanDeleteComplex(newComplex);
        }
        public bool IsPlanAvailable(Complex newComplex)
        {
            return DataAccess != null && DataAccess.CanDeleteComplex(newComplex);
        }
        
        public bool AddComplex(Complex newComplex)
        {
            return DataAccess != null && DataAccess.InsertComplex(newComplex);
        }

        public Complex GetComplex(Complex selectComplex)
        {
            if (DataAccess != null) return DataAccess.SelectComplex(selectComplex);
            return new Complex();
        }

        public bool SetComplex(Complex updateComplex)
        {
            return DataAccess != null && DataAccess.UpdateComplex(updateComplex);
        }

        public bool DeleteComplex(Complex deleteComplex)
        {
            return DataAccess != null && DataAccess.DeleteComplex(deleteComplex);
        }

        #endregion

    }
}
