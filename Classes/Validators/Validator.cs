using System;
using Esoft.Classes.DataAdapters;
using Esoft.Classes.Models.Complex;
using Esoft.Classes.Models.House;

namespace Esoft.Classes.Validators
{
    public class Validator
    {
        public HouseAdapter HouseAdapter { get; set; }
        public ComplexAdapter ComplexAdapter { get; set; }
        public string ValidateComplex(Complex complex)
        {
            if (complex == null)
            {
                return "Ошибка передачи данных";
            }
            if (String.IsNullOrEmpty(complex.NameHousingComplex))
            {
                return "Введите имя жилищного комплекса";
            }
            if (complex.AddedValue < 0)
            {
                return "Добавочная стоимость должна быть неотрицательной";
            }
            if (String.IsNullOrEmpty(complex.StatusConstructionHousingComplex))
            {
                return "Укажите статус ЖК";
            }
            if (complex.BuildingCost < 0)
            {
                return "Затраты на строительство должны быть неотрицательными";
            }
            if (String.IsNullOrEmpty(complex.City))
            {
                return "Укажите город";
            }
            if (complex.AddedValue < 0)
            {
                return "Добавочная стоимость должна быть неотрицательной";
            }
            if (String.IsNullOrEmpty(complex.StatusConstructionHousingComplex))
            {
                return "Укажите статус ЖК";
            }
            if (complex.BuildingCost < 0)
            {
                return "Затраты на строительство должны быть неотрицательными";
            }
            if (String.IsNullOrEmpty(complex.City))
            {
                return "Укажите город";
            }
            if(complex.StatusConstructionHousingComplex.Equals(Const.StatusConstructionValue.Plan))
            {
                ComplexAdapter = new ComplexAdapter();
                if(!ComplexAdapter.IsPlanAvailable(complex))
                    return "Невозможно установить выбранный статус т.к. в данном комплексе есть проданные квартиры";
            }
            if (!complex.StatusConstructionHousingComplex.Equals(Const.StatusConstructionValue.Plan))
            {
                return String.Empty; //validated
            }
            HouseAdapter = new HouseAdapter();
            if (!ComplexAdapter.IsPlanAvailable(complex))
            {
                return "Невозможно установить выбранный статус т.к. в данном комплексе есть проданные квартиры";
            }
                
            return String.Empty; //validated
        }

        public string ValidateHouse(House house)
        {
            
            if (house == null)
            {
                return "Ошибка передачи данных";
            }
            if (String.IsNullOrWhiteSpace(house.Street))
            {
                return "Введите улицу";
            }
            if (String.IsNullOrWhiteSpace(house.NumberHouse))
            {
                return "Введите номер дома";
            }
            if (house.IdComplex==default)
            {
                return "Выберите ЖК";
            }
            if (house.CostHouseConstruction < 0)
            {
                return "Затраты на строительство должны быть неотрицательными";
            }
            if (house.AdditionalCostHouseConstruction < 0)
            {
                return "Rоэффициент добавочной стоимости должен быть неотрицательным";
            }
            return String.Empty; //validated
        }



    }
}
