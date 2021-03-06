﻿using System.Collections.Generic;
using Esoft.DataAccess.DataSqlGateways;
using Esoft.Models.Apartment;

namespace Esoft.DataAccess.DataAdapters
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
            List<Apartment> apartmentList = ApartmentAccess.SelectAllApartment();
            return apartmentList ?? new List<Apartment>();
        }
        public List<ApartmentWithComplexes> GetAllApartmentWithComplexes()
        {
            List<ApartmentWithComplexes> apartmentList = ApartmentAccess.SelectAllApartmentWithComplexes();
            return apartmentList ?? new List<ApartmentWithComplexes>();
        }


        public bool AddApartment(Apartment newApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.InsertApartment(newApartment);
        }

        public Apartment GetApartment(Apartment selectApartment)
        {
            return ApartmentAccess != null 
                ? ApartmentAccess.SelectApartment(selectApartment) 
                : new Apartment();
        }


        public ApartmentWithComplexes GetApartmentWithComplexes(Apartment selectApartment)
        {
            return new ApartmentWithComplexes();
        }


        public bool SetApartment(Apartment updateApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.UpdateApartment(updateApartment);
        }

        public bool DeleteApartment(Apartment deleteApartment)
        {
            return ApartmentAccess != null && ApartmentAccess.DeleteApartment(deleteApartment);
        }
    }
}
